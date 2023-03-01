using BAS24.Auth.Infrastructure.Postgres.Media;
using BAS24.Auth.Infrastructure.Postgres.User;
using Microsoft.EntityFrameworkCore;

namespace BAS24.Auth.Infrastructure.DbConfigs;

public static class UserTableConfig
{
  public static ModelBuilder AddUserTableRelationship(this ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<UserTable>()
      .HasMany(i => i.Stores)
      .WithOne(i => i.Owner)
      .HasForeignKey(i=> i.OwnerId);

    modelBuilder.Entity<UserTable>()
      .HasOne(i => i.Media)
      .WithOne()
      .HasForeignKey<MediaTable>(i=> i.MasterId);
    return modelBuilder;
  }
}
