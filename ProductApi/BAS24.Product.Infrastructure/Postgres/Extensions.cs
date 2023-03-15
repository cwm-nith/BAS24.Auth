using BAS24.Libs.Postgres;
using BAS24.Product.Core.IRepositories;
using BAS24.Product.Infrastructure.Postgres.Currency;
using BAS24.Product.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BAS24.Product.Infrastructure.Postgres;

public static class Extensions
{
  public static IServiceCollection AddPostgresRepositories(this IServiceCollection services)
  {
    services.AddPostgresRepository<CurrencyTable>();
    
    services.AddScoped(typeof(PostgresDbContext),
      sp =>
      {
        var options = sp.CreateScope().ServiceProvider.GetRequiredService<DbContextOptions<PostgresDbContext>>();
        return new PostgresDbContext(options);
      });

    services.AddTransient<ICurrencyRepository, CurrencyRepository>();
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