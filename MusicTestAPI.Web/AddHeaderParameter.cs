using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.Swagger;
using System.Collections.Generic;
using IOperationFilter = Swashbuckle.AspNetCore.SwaggerGen.IOperationFilter;

namespace MusicTestAPI.Web
{
    public class AddHeaderParameter:IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "jwt-token",
                In = ParameterLocation.Header,
                Description = "the jwt token for the request",
                Required = false
            });
        }
    }
}
