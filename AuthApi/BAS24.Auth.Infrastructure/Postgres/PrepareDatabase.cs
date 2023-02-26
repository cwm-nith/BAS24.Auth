using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BAS24.Auth.Infrastructure.Postgres;

public static class PrepareDatabase
{
  public static void PrepareDatabasePopulation(IApplicationBuilder app)
  {
    using var service = app.ApplicationServices.CreateScope();
    MigrationDatabase(service.ServiceProvider.GetService<PostgresDbContext>());
  }

  private static void MigrationDatabase(DbContext? context)
  {
    Console.WriteLine("Applying migration ...");
    context?.Database.Migrate();
  }
}
