using BAS24.Auth.Infrastructure.Postgres.SocialLink;
using Microsoft.EntityFrameworkCore;

namespace BAS24.Auth.Infrastructure.DbConfigs;

public static class SocialLinkTableConfig
{
  public static ModelBuilder AddSocialLinkTableRelationship(this ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<SocialLinkTable>()
      .HasMany(i => i.SocialUserLinks)
      .WithOne(i => i.SocialLink)
      .HasForeignKey(i => i.SocialLinkId);

    modelBuilder.Entity<SocialLinkTable>()
      .HasMany(i => i.Medias)
      .WithOne()
      .HasForeignKey(i => i.MasterId);
    return modelBuilder;
  } 
}
