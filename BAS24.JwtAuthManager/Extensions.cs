using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BAS24.JwtAuthManager;

public static class Extensions
{
  public static IServiceCollection AddJwtAuthManager(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
        options.SaveToken = true;
        options.RequireHttpsMetadata = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidAudience = configuration["Jwt:Audience"],
          ValidIssuer = configuration["Jwt:Site"],
          IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SigningKey"] ?? "")),
          ValidateLifetime = false
        };
      });
    return services;
  }
}
