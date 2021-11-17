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
        public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            this.EntityMapper = mapper;
        }

        public override bool CheckIfUserExists(User user)
        {
            bool result = false;
        
                result=this.UnitOfWrk.Users.Get((u => u.Email == user.Email)).Any();
         
            return result;
        }

        public override OperationResult Create(User userToCreate)
        {
            OperationResult result;
            try
            {
                if (CheckIfUserExists(userToCreate))
                {
                    result = new OperationResult();
                    result.ErrorMessage = "User already exists, please login";
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
                        result = new OperationResult();
                        result.IsSuccesfull = true;
                        result.Result = OpCodes.Succesfull;
                    }
                    else
                    {
                        result = new OperationResult();
                        result.ErrorMessage = "The password or email doesnt have a valid format";
                        result.IsSuccesfull = false;
                        result.Result = OpCodes.Error;
                    }
                }
            }
            catch (Exception exc)
            {
                result = new OperationResult();
                result.ErrorMessage = $"{exc.Message}\n{exc.StackTrace}";
                result.IsSuccesfull = false;
                result.Result = OpCodes.Error;
            }
            return result;
        }

        public override OperationResult Login(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
