
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicTestAPI.Web
{
    public class AuthServiceFilter : Swashbuckle.AspNetCore.SwaggerGen.IDocumentFilter
    {
        private string tokenUrlRoute = "api/Users";
        // the above is the action which returns token against valid credentials
        private Dictionary<HeaderType, OpenApiParameter> headerDictionary;
        private enum HeaderType { TokenAuth };

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            CreateHeaders();

            var pathItems = swaggerDoc.Paths.Where(entry => !entry.Key.Contains(tokenUrlRoute)) 
                .Select(entry => entry.Value)
                .ToList();

            foreach (var path in pathItems)
            {
                AddHeadersToPath(path, HeaderType.TokenAuth);
            }
        }

        private void AddHeadersToPath(OpenApiPathItem path, params HeaderType[] headerTypes)
        {
            if (path.Parameters != null)
            {
                path.Parameters.Clear();
            }
            else
            {
                path.Parameters = new List<OpenApiParameter>();
            }

            foreach (var type in headerTypes)
            {
                path.Parameters.Add(headerDictionary[type]);
            }
        }

        private void CreateHeaders()
        {
            headerDictionary = new Dictionary<HeaderType, OpenApiParameter>();
            headerDictionary.Add(HeaderType.TokenAuth, new OpenApiParameter
            {
                Name = "jwt-token",
                In = ParameterLocation.Header,
                Description = "the jwt token for the request",
                Required = true
            });
        }
    }
}
