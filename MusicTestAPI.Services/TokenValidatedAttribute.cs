using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using MusicTestAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Services
{
    public class TokenValidatedAttribute : Attribute, IAsyncActionFilter
    {
        private ILogger logger;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<TokenValidatedAttribute>>();
            var jwtAuthenticationResult = ValidateJwtTokenAsync<JwtAuthenticationResponse>(context);
            if(!jwtAuthenticationResult.IsSuccesfull)
            {
                context.Result = new UnauthorizedObjectResult(jwtAuthenticationResult);
                logger.LogInformation($"Token validation completed with status: {jwtAuthenticationResult}");
                return;
            }
            await next();
        }

        private T ValidateJwtTokenAsync<T>(ActionExecutingContext context)
        {
            bool isValidToken = false;
            ITokenAuthenticator tokenAuthenticator = context.HttpContext.RequestServices.GetRequiredService<ITokenAuthenticator>();
            try
            {
                if (context.HttpContext.Request.Headers.TryGetValue("jwt-token", out StringValues userToken))
                {
                    isValidToken = tokenAuthenticator.IsValidToken(userToken);
                    if (isValidToken)
                    {
                        var response = new JwtAuthenticationResponse() { IsSuccesfull = isValidToken };
                        return (T)Convert.ChangeType(response, typeof(T));
                    }
                    else
                    {
                        var resp = new JwtAuthenticationResponse { IsSuccesfull = isValidToken, ErrorMessage = "Invalid token" };
                        return (T)Convert.ChangeType(resp, typeof(T));
                    }
                }
                else
                {
                    var resp = new JwtAuthenticationResponse { IsSuccesfull = isValidToken, ErrorMessage = "The 'jwt-token' header is required" };
                    return (T)Convert.ChangeType(resp, typeof(T));
                }
            }
            catch (Exception exc)
            {
                var resp = new JwtAuthenticationResponse { IsSuccesfull = isValidToken, ErrorMessage = "Exception Occurred." };
                logger.LogInformation($"Error validating jwt-token\n{exc.Message}\n{exc.StackTrace} ");
                return (T)Convert.ChangeType(resp, typeof(T));
                throw;
            }
        }
    }
}
