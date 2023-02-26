using System.Text;
using BAS24.Auth.Infrastructure;
using BAS24.Libs.CQRS.Handlers;
using BAS24.Libs.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddDefaultJsonOptions(); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCommandCorrelationContextHandlers();
builder.Services.AddEventCorrelationContextHandlers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
  {
    options.SaveToken = true;
    options.RequireHttpsMetadata = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
      ValidateIssuer = true,
      ValidateAudience = true,
      ValidAudience = builder.Configuration["Jwt:Audience"],
      ValidIssuer = builder.Configuration["Jwt:Site"],
      IssuerSigningKey =
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SigningKey"] ?? "")),
      ValidateLifetime = false
    };
  });
var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
app.UseSwagger(c =>
{
  c.RouteTemplate = "swagger/{documentName}/swagger.json";
});

app.UseSwaggerUI(c =>
{
  foreach (var description in provider.ApiVersionDescriptions)
  {
    c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
  }

  c.RoutePrefix = "swagger";
});


// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseInfrastructure();

app.MapControllers();

app.Run();
