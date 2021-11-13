using MusicTestAPI.Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Services.Interfaces
{
    public interface IUserService
    {
        public void Create(User userToCreate);

        public void Login(string userName, string password);

    }
}
