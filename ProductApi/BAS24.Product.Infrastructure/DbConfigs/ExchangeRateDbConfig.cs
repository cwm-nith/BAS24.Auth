using BAS24.Product.Infrastructure.Postgres.ExchangeRate;
using Microsoft.EntityFrameworkCore;

namespace BAS24.Product.Infrastructure.DbConfigs;

public static class ExchangeRateTableConfig
{
  public static ModelBuilder AddExchangeRateTableRelationship(this ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<ExchangeRateTable>()
      .HasOne(i => i.Currency)
      .WithOne().HasForeignKey<ExchangeRateTable>(i => i.CurrencyId);
    return modelBuilder;
  }
}
