using System.ComponentModel.DataAnnotations.Schema;
using BAS24.Libs.Postgres;

namespace BAS24.Product.Infrastructure.Postgres.Store;

[Table("stores")]
public class StoreTable:BasePostgresTable
{
  [Column("store_id")]
  public Guid StoreId { get; set; }
  [Column("owner_id")]
  public Guid OwnerId { get; set; }
  [Column("active")]
  public bool Active { get; set; }

  public List<StoreMemberTable> StoreMembers { get; set; }
}
