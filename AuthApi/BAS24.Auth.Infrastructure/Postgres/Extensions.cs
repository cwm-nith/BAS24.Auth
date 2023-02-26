using BAS24.Api.IRepositories;
using BAS24.Auth.Infrastructure.Postgres.User;
using BAS24.Auth.Infrastructure.Repositories;
using BAS24.Libs.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BAS24.Auth.Infrastructure.Postgres;

public static class Extensions
{
  public static IServiceCollection AddPostgresRepositories(this IServiceCollection services)
  {
    services.AddPostgresRepository<UserTable>();

    services.AddScoped(typeof(PostgresDbContext),
      sp =>
      {
        var options = sp.CreateScope().ServiceProvider.GetRequiredService<DbContextOptions<PostgresDbContext>>();
        return new PostgresDbContext(options);
      });

    services.AddTransient<IUserRepository, UserRepository>();
    services.AddTransient<ITwilioRepository, TwilioRepository>();
    //services.AddTransient<IDbRepository, DbRepository>();

    //services.AddTransient<IReportRepository, ReportRepository>();

    // services.AddTransient<IDbRepository, DbRepository>(sp =>
    // {
    //   var context = services.BuildServiceProvider().GetRequiredService<PostgresDbContext>();
    //   return new DbRepository(context);
    // });
    //
    // services.AddTransient<IReportRepository, ReportRepository>(sp =>
    // {
    //   var context = services.BuildServiceProvider().GetRequiredService<PostgresDbContext>();
    //   return new ReportRepository(context);
    // });

    return services;
  }

  private static IServiceCollection AddPostgresRepository<TTable>(this IServiceCollection services)
    where TTable : BasePostgresTable
  {
    services.AddTransient<IPostgresRepository<TTable>>(sp =>
    {
      var context = services.BuildServiceProvider().GetRequiredService<PostgresDbContext>();
      return new PostgresRepository<TTable>(context);
    });

    return services;
  }
}
