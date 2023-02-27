using BAS24.Auth.Infrastructure.Postgres.Media;
using BAS24.Auth.Infrastructure.Postgres.SocialLink;
using BAS24.Auth.Infrastructure.Postgres.Store;
using BAS24.Auth.Infrastructure.Postgres.User;
using Microsoft.EntityFrameworkCore;

namespace BAS24.Auth.Infrastructure.Postgres;

public class PostgresDbContext : DbContext
{
  public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
  {
  }

  public DbSet<UserTable>? Users { get; set; }
  public DbSet<MediaTable>? Medias { get; set; }
  public DbSet<SocialLinkTable>? SocialLinks { get; set; }
  public DbSet<SocialUserLinkTable>? SocialUserLinks { get; set; }
  public DbSet<StoreMemberTable>? StoreMembers { get; set; }
  public DbSet<StoreTable>? Stores { get; set; }


  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.Entity<UserTable>()
      .HasMany(i => i.Stores)
      .WithOne(i => i.Owner)
      .HasForeignKey(i=> i.OwnerId);

    modelBuilder.Entity<SocialLinkTable>()
      .HasMany(i => i.SocialUserLinks)
      .WithOne(i => i.SocialLink)
      .HasForeignKey(i => i.SocialLinkId);

    modelBuilder.Entity<StoreTable>()
      .HasMany(i => i.SocialUserLinks)
      .WithOne(i => i.Store)
      .HasForeignKey(i => i.StoreId);
    modelBuilder.Entity<StoreTable>()
      .HasMany(i => i.StoreMembers)
      .WithOne(i => i.Store)
      .HasForeignKey(i => i.StoreId);
  }
}
