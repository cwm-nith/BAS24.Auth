using BAS24.Api.Entities.User;
using BAS24.Api.Exceptions.Middlewares;
using BAS24.Api.Middlewares;
using BAS24.Auth.Infrastructure.Options;
using BAS24.Auth.Infrastructure.Postgres;
using BAS24.Auth.Infrastructure.Services;
using BAS24.Auth.Infrastructure.Services.Interfaces;
using BAS24.Auth.Infrastructure.Swagger.CustomizeHeader;
using BAS24.Auth.Infrastructure.Swagger.RequestExamples;
using BAS24.Libs.CQRS.Commands;
using BAS24.Libs.CQRS.Events;
using BAS24.Libs.CQRS.Queries;
using BAS24.Libs.Jwt;
using BAS24.Libs.Logging;
using BAS24.Libs.Postgres;
using BAS24.Libs.SpecialPassword;
using BAS24.Libs.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Twilio.Clients;

namespace BAS24.Auth.Infrastructure;

public static class Extensions
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddTransient<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>();
    services.AddTransient<ITokenProvider<UserEntity>, TokenProvider<UserEntity>>();
    services.AddJwt(configuration);
    services.AddSpecialPassword();

    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
    services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
    services.AddSingleton<IEventDispatcher, EventDispatcher>();

    services.AddCommandHandlers();
    services.AddQueryHandlers();
    services.AddEventHandlers();

    services.AddHttpClient<ITwilioRestClient, TwilioService>();

    services.AddTransient<IUserService, UserService>();

    services.AddPostgres<PostgresDbContext>();
    services.AddPostgresRepositories();

    services.ConfigureOptions<ConfigureSwaggerOptions>();
    services.AddApiVersioning(setup =>
    {
      setup.DefaultApiVersion = new ApiVersion(1, 0);
      setup.AssumeDefaultVersionWhenUnspecified = true;
      setup.ReportApiVersions = true;
    });

    services.AddVersionedApiExplorer(setup =>
    {
      setup.GroupNameFormat = "'v'VVV";
      setup.SubstituteApiVersionInUrl = true;
    });
    // services.AddSwagger<AuthorizationHeaderParameterOperationFilter>("BAS24.Auth.Api.xml").AddSwaggerExample();
    services.AddSwagger<AuthorizationHeaderParameterOperationFilter>("BAS24.Auth.Api.xml").AddSwaggerExample();

    services.Configure<ForwardedHeadersOptions>(options =>
    {
      options.ForwardedHeaders = ForwardedHeaders.All;
    });
    return services;
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
