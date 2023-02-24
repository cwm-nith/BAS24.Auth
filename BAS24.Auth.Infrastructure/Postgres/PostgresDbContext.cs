using BAS24.Auth.Infrastructure.Postgres.User;
using Microsoft.EntityFrameworkCore;

namespace BAS24.Auth.Infrastructure.Postgres;

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
