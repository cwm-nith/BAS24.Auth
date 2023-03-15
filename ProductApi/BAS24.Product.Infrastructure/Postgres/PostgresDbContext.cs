using BAS24.Product.Infrastructure.Postgres.Currency;
using Microsoft.EntityFrameworkCore;

namespace BAS24.Product.Infrastructure.Postgres;

public class PostgresDbContext : DbContext
{
  public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
  {
  }

  public DbSet<CurrencyTable>? Currencies { get; set; }


  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    // modelBuilder
    //   .AddUserTableRelationship()
    //   .AddStoreTableRelationship()
    //   .AddSocialLinkTableRelationship()
    //   .AddStoreMemberTableRelationship()
    //   .AddAddMemberToStoreRequestTableRelationship();
  }
}
