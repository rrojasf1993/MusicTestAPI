using MusicTestAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Services
{
    public abstract class BaseTokenAuthenticator:ITokenAuthenticator
    {
        protected  string privateKey;

        protected abstract void GetPrivateKey();
        public abstract string GenerateToken();
        public abstract bool IsValidToken(string token);
    }
}
