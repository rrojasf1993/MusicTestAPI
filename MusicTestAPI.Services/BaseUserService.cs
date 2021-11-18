using AutoMapper;
using MusicTestAPI.Common.DataTransferObjects;
using MusicTestAPI.Data.Interfaces;
using MusicTestAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MusicTestAPI.Services
{
    public abstract class BaseUserService : IUserService
    {
        public IMapper EntityMapper { get; set; }
        public IUnitOfWork UnitOfWrk { get; set; }
        public ITokenAuthenticator TokenAuthenticator { get; set; }

        public abstract OperationResult Create(User userToCreate);

        public abstract OperationResult Login(string userName, string password);

        public bool IsPasswordValid(string password)
        {
            Regex passwordRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{10,}$");
            return passwordRegex.IsMatch(password);
        }

        public abstract bool CheckIfUserExists(User user);
       
        public BaseUserService(IUnitOfWork unitOfWork, ITokenAuthenticator tokenAuthenticator)
        {
            this.UnitOfWrk = unitOfWork;
            this.TokenAuthenticator = tokenAuthenticator;
        }
    }
}
