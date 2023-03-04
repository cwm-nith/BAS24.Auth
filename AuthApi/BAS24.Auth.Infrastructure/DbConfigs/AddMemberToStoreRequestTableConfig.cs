using BAS24.Auth.Infrastructure.Postgres.Store;
using Microsoft.EntityFrameworkCore;

namespace BAS24.Auth.Infrastructure.DbConfigs;

public static class AddMemberToStoreRequestTableConfig
{
  public static ModelBuilder AddAddMemberToStoreRequestTableRelationship(this ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<AddMemberToStoreRequestTable>()
      .HasOne(i => i.Store)
      .WithOne()
      .HasForeignKey<AddMemberToStoreRequestTable>(i => i.StoreId);

    modelBuilder.Entity<AddMemberToStoreRequestTable>()
      .HasOne(i => i.Member)
      .WithOne()
      .HasForeignKey<AddMemberToStoreRequestTable>(i => i.MemberId);
    
    modelBuilder.Entity<AddMemberToStoreRequestTable>()
      .HasOne(i => i.StoreMember)
      .WithOne()
      .HasForeignKey<AddMemberToStoreRequestTable>(i => i.StoreMemberId);
    
    modelBuilder.Entity<AddMemberToStoreRequestTable>()
      .HasOne(i => i.ByUser)
      .WithOne()
      .HasForeignKey<AddMemberToStoreRequestTable>(i => i.ById);
    return modelBuilder;
  } 
}
