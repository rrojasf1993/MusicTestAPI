using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Services
{
    public class JwtTokenAuthenticator : BaseTokenAuthenticator
    {
        public JwtTokenAuthenticator()
        {
            GetPrivateKey();
        }

        public override string GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.privateKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var myToken = new JwtSecurityToken(
                signingCredentials: credentials,
                issuer: "MusicTestAPI.Services",
                audience: "MusicTestAPI.Clients",
                claims: new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub,"value")
                },
                expires: DateTime.UtcNow.AddMinutes(20));

            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(myToken);
        }

        public override bool IsValidToken(string token)
        {
            throw new NotImplementedException();
        }

        protected override void GetPrivateKey()
        {
            throw new NotImplementedException();
        }
    }
}
