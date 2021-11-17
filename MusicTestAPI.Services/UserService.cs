using AutoMapper;
using MusicTestAPI.Common;
using MusicTestAPI.Common.DataTransferObjects;
using MusicTestAPI.Data.Interfaces;
using MusicTestAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Services
{
    public class UserService : BaseUserService
    {

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ITokenAuthenticator tokenAuthenticator) : base(unitOfWork,tokenAuthenticator)
        {
            this.EntityMapper = mapper;
            this.TokenAuthenticator = tokenAuthenticator;
        }

        public override bool CheckIfUserExists(User user)
        {
            bool result = false;
            result=this.UnitOfWrk.Users.Get((u => u.Email == user.Email)).Any();
            return result;
        }

        public override OperationResult Create(User userToCreate)
        {
            OperationResult result = new OperationResult();
            try
            {
                if (CheckIfUserExists(userToCreate))
                {
                    result = new OperationResult();
                    result.ErrorMessages.Add("User already exists, please login");
                    result.IsSuccesfull = false;
                    result.Result = OpCodes.Error;
                }
                else
                {
                    if (IsPasswordValid(userToCreate.Password) && Util.IsValidEmail(userToCreate.Email))
                    {
                        var userToInsert = new MusicTestAPI.Data.Entities.User();
                        userToInsert = this.EntityMapper.Map<Common.DataTransferObjects.User, Data.Entities.User>(userToCreate, userToInsert);
                        this.UnitOfWrk.Users.Insert(userToInsert);
                        this.UnitOfWrk.SaveChanges();
                        result.ErrorMessages.Clear();
                        result.IsSuccesfull = true;
                        result.Result = OpCodes.Succesfull;
                    }
                    else
                    {
                        
                        result.ErrorMessages.Add("The password or email doesnt have a valid format");
                        result.IsSuccesfull = false;
                        result.Result = OpCodes.Error;
                    }
                }
            }
            catch (Exception exc)
            {
                result.ErrorMessages.Add("{exc.Message}\n{exc.StackTrace}");
                result.IsSuccesfull = false;
                result.Result = OpCodes.Error;
            }
            return result;
        }

        public override OperationResult Login(string email, string password)
        {
            OperationResult result = new OperationResult(); ;
            try
            {
                if (!Util.IsValidEmail(email))
                {
                    result.IsSuccesfull = false;
                    result.ErrorMessages.Add("Email must have a valid format");
                    result.Result = OpCodes.Error;
                }
                else
                {
                    User userToCheck = new User() { Email = email };
                    if(CheckIfUserExists(userToCheck))
                    {
                        if (IsPasswordValid(password))
                        {
                            Common.DataTransferObjects.User loggedUserData;
                            var loggedUser=this.UnitOfWrk.Users.Get((u => u.Email == email && u.Password == password)).FirstOrDefault();
                            if (loggedUser != null)
                            {
                                loggedUserData =this.EntityMapper.Map<Common.DataTransferObjects.User>(loggedUser);
                                loggedUserData.UserToken =this.TokenAuthenticator.GenerateToken();
                                result.ErrorMessages.Clear();
                                result.Result = loggedUserData;
                                result.IsSuccesfull = true;
                            }
                            else
                            {
                                result.IsSuccesfull = false;
                                result.ErrorMessages.Add("User name or password is invalid");
                                result.Result = OpCodes.Unauthorized;
                            }
                        }
                        else
                        {
                            result.IsSuccesfull = false;
                            result.ErrorMessages.Add("Password has a invalid format");
                            result.Result = OpCodes.Error;
                        }
                    }
                    else
                    {
                        result.IsSuccesfull = false;
                        result.ErrorMessages.Add("User doesn't exist");
                        result.Result = OpCodes.Unauthorized;
                    }
                }
            }
            catch (Exception exc)
            {
                result.ErrorMessages.Add( $"{exc.Message}\n{exc.StackTrace}");
                result.IsSuccesfull = false;
                result.Result = OpCodes.Error;
            }
            return result;
        }
    }
}
