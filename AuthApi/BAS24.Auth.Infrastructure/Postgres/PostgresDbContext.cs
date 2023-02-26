using Infra.Postgres.User;
using Microsoft.EntityFrameworkCore;

namespace Infra.Postgres;

public class PostgresDbContext : DbContext
{
  public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
  {
  }

  public DbSet<UserTable>? Users { get; set; }


  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
  }
}
