using System.ComponentModel.DataAnnotations.Schema;
using BAS24.Libs.Postgres;

namespace BAS24.Product.Infrastructure.Postgres.Store;

[Table("store_members")]
public class StoreMemberTable:BasePostgresTable
{
  [Column("local_store_id")]
  public Guid LocalStoreId { get; set; }
  [Column("store_id")]
  public Guid StoreId { get; set; } // store id from other service
  [Column("member_id")]
  public Guid MemberId { get; set; }
  [Column("name")]
  public string Name { get; set; } = string.Empty;
  [Column("permission")]
  public int Permission { get; set; }

  public StoreTable? Store { get; set; }
}
