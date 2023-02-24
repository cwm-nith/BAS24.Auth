using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BAS24.Auth.Infrastructure.Swagger.CustomizeHeader;

public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
{
  public void Apply(OpenApiOperation operation, OperationFilterContext context)
  {
    operation.Parameters ??= new List<OpenApiParameter>();

    operation.Parameters.Add(new OpenApiParameter
    {
      Name = "X-Client",
      In = ParameterLocation.Header,
      Description = "Authorization header",
      Required = false,
      Schema = new OpenApiSchema { Type = "String", Default = new OpenApiString("WbNk6U3") }
    });
  }
}
