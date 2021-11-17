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

        public abstract OperationResult Create(User userToCreate);

        public abstract OperationResult Login(string userName, string password);

        public bool IsPasswordValid(string password)
        {
            Regex passwordRegex = new Regex("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\\S+$).{3, 10}$");
            return passwordRegex.IsMatch(password);
        }

        public abstract bool CheckIfUserExists(User user);
       
        public BaseUserService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWrk = unitOfWork;
        }
    }
}
