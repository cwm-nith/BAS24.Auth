using BAS24.Auth.Infrastructure.Postgres.Media;
using BAS24.Auth.Infrastructure.Postgres.Store;
using Microsoft.EntityFrameworkCore;

namespace BAS24.Auth.Infrastructure.DbConfigs;

public static class StoreTableConfig
{
  public static ModelBuilder AddStoreTableRelationship(this ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<StoreTable>()
      .HasMany(i => i.SocialUserLinks)
      .WithOne(i => i.Store)
      .HasForeignKey(i => i.StoreId);
    modelBuilder.Entity<StoreTable>()
      .HasMany(i => i.StoreMembers)
      .WithOne(i => i.Store)
      .HasForeignKey(i => i.StoreId);

    modelBuilder.Entity<StoreTable>()
      .HasMany(i => i.Medias)
      .WithOne()
      .HasForeignKey(i=> i.MasterId);
    return modelBuilder;
  }
}
