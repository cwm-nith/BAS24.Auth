using BAS24.Auth.Infrastructure;
using BAS24.Libs.CQRS.Handlers;
using BAS24.Libs.Json;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddDefaultJsonOptions();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructure();
builder.Services.AddCommandCorrelationContextHandlers();
builder.Services.AddEventCorrelationContextHandlers();

var app = builder.Build();
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
