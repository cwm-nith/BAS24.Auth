using BAS24.Product.Infrastructure.DbConfigs;
using BAS24.Product.Infrastructure.Postgres.Currency;
using BAS24.Product.Infrastructure.Postgres.ExchangeRate;
using BAS24.Product.Infrastructure.Postgres.Store;
using Microsoft.EntityFrameworkCore;

namespace BAS24.Product.Infrastructure.Postgres;

public class PostgresDbContext : DbContext
{
  public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
  {
  }

  public DbSet<CurrencyTable>? Currencies { get; set; }
  public DbSet<ExchangeRateTable>? ExchangeRates { get; set; }
  public DbSet<StoreTable>? Stores { get; set; }
  public DbSet<StoreMemberTable>? StoreMembers { get; set; }



  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder
      .AddExchangeRateTableRelationship()
      .AddStoreTableRelationship();
  }
}
