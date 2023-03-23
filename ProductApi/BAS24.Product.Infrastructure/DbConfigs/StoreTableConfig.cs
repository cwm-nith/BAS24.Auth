using BAS24.Product.Infrastructure.Postgres.ExchangeRate;
using BAS24.Product.Infrastructure.Postgres.Store;
using Microsoft.EntityFrameworkCore;

namespace BAS24.Product.Infrastructure.DbConfigs;

public static class StoreTableConfig
{
  public static ModelBuilder AddStoreTableRelationship(this ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<StoreTable>()
      .HasMany(i => i.StoreMembers)
      .WithOne(i => i.Store);
    return modelBuilder;
  }
}
