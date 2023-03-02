using BAS24.Auth.Infrastructure.Postgres.Store;
using Microsoft.EntityFrameworkCore;

namespace BAS24.Auth.Infrastructure.DbConfigs;

public static class StoreMemberTableConfig
{
  public static ModelBuilder AddStoreMemberTableRelationship(this ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<StoreMemberTable>()
      .HasOne(i => i.User)
      .WithOne()
      .HasForeignKey<StoreMemberTable>(i => i.MemberId);
    return modelBuilder;
  } 
}
