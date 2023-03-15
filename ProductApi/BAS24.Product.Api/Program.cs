using BAS24.JwtAuthManager;
using BAS24.Libs.CQRS.Handlers;
using BAS24.Libs.Json;
using BAS24.Product.Infrastructure;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers().AddDefaultJsonOptions(); 

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCommandCorrelationContextHandlers();
builder.Services.AddEventCorrelationContextHandlers();

builder.Services.AddJwtAuthManager(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseInfrastructure();
app.MapControllers();

app.Run();
