using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Services.Interfaces
{
    public interface ITokenAuthenticator
    {
        string GenerateToken();
        bool IsValidToken(string token);
    }
}
