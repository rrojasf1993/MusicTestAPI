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

        public override bool IsValidToken(string tokenToValidate)
        {
            bool validationResult;
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = (new TokenValidationParameters()
                {
                    ValidateLifetime = false,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidIssuer = "MusicTestAPI.Services",
                    ValidAudience = "MusicTestAPI.Clients",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.privateKey))
                });
                var principal = tokenHandler.ValidateToken(tokenToValidate, validationParameters, out SecurityToken securityToken);
                validationResult = true;
            }
            catch (Exception exc)
            {

                return false;
            }
            return validationResult;
        }

        protected override void GetPrivateKey()
        {
            this.privateKey = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
        }
    }
}
