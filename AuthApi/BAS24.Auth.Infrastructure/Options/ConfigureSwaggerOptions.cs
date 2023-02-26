using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Infra.Options;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
  private readonly IApiVersionDescriptionProvider _provider;

  public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
  {
    _provider = provider;
  }

  public void Configure(SwaggerGenOptions options)
  {
    foreach (var description in _provider.ApiVersionDescriptions)
    {
      options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
    }
  }

  private static OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
  {
    var info = new OpenApiInfo { Title = "BAS24.Auth.API", Version = description.ApiVersion.ToString() };
    return info;
  }
}
