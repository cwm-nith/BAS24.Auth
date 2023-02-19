using BAS24.Api.Exceptions.Middlewares;
using BAS24.Api.Middlewares;
using BAS24.Auth.Infrastructure.Options;
using BAS24.Auth.Infrastructure.Postgres;
using BAS24.Auth.Infrastructure.Swagger.CustomizeHeader;
using BAS24.Auth.Infrastructure.Swagger.RequestExamples;
using BAS24.Libs.CQRS.Commands;
using BAS24.Libs.CQRS.Events;
using BAS24.Libs.CQRS.Queries;
using BAS24.Libs.Logging;
using BAS24.Libs.Postgres;
using BAS24.Libs.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BAS24.Auth.Infrastructure;

public static class Extensions
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection service)
  {
    service.AddCommandHandlers();
    service.AddQueryHandlers();
    service.AddEventHandlers();

    service.AddPostgres<PostgresDbContext>();
    service.AddPostgresRepositories();

    service.ConfigureOptions<ConfigureSwaggerOptions>();
    service.AddApiVersioning(setup =>
    {
      setup.DefaultApiVersion = new ApiVersion(1, 0);
      setup.AssumeDefaultVersionWhenUnspecified = true;
      setup.ReportApiVersions = true;
    });

    service.AddVersionedApiExplorer(setup =>
    {
      setup.GroupNameFormat = "'v'VVV";
      setup.SubstituteApiVersionInUrl = true;
    });
    // service.AddSwagger<AuthorizationHeaderParameterOperationFilter>("BAS24.Auth.Api.xml").AddSwaggerExample();
    service.AddSwagger<AuthorizationHeaderParameterOperationFilter>("BAS24.Auth.Api.xml").AddSwaggerExample();

    service.Configure<ForwardedHeadersOptions>(options =>
    {
      options.ForwardedHeaders = ForwardedHeaders.All;
    });
    return service;
  }

  public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
  {
    // var supportedCultures = new[]
    // {
    //     new CultureInfo("en-US"),
    //     new CultureInfo("fr")
    // };

    app.UseForwardedHeaders();

    app.UseErrorHandler()
      .UseMiddleware<AuthorizationRequestHandlerMiddleware>()
      .UseMiddleware<LogMiddleware>()
      // .UseInitializer()
      //.UseIpRateLimiting()
      // .UseRequestLocalization(new RequestLocalizationOptions
      // {
      //     DefaultRequestCulture = new RequestCulture("en-US"),
      //     // Formatting numbers, dates, etc.
      //     SupportedCultures = supportedCultures,
      //     // UI strings that we have localized.
      //     SupportedUICultures = supportedCultures
      // })
      .UseAllForwardedHeaders()
      .UseLogUserIdMiddleware();

    return app;
  }

  private static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
  {
    return builder.UseMiddleware<ErrorHandlerMiddleware>();
  }

  // private static IApplicationBuilder UseInitializer(this IApplicationBuilder builder)
  // {
  //     using var scope = builder.ApplicationServices.CreateScope();
  //     var sp = scope.ServiceProvider;
  //
  //     sp.GetRequiredService<IPostgresInitializer>().InitializeAsync();
  //
  //     return builder;
  // }
  private static IApplicationBuilder UseAllForwardedHeaders(this IApplicationBuilder builder)
  {
    return builder.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });
  }

  private static IApplicationBuilder UseLogUserIdMiddleware(this IApplicationBuilder builder)
  {
    return builder.UseMiddleware<LogUserIdMiddleware>();
  }
}
