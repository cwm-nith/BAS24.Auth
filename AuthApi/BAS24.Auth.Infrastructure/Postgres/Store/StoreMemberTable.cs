using System.ComponentModel.DataAnnotations.Schema;
using BAS24.Auth.Infrastructure.Postgres.User;
using BAS24.Libs.Postgres;

namespace BAS24.Auth.Infrastructure.Postgres.Store;

[Table("store_members")]
public class StoreMemberTable : BasePostgresTable
{
  [Column("store_id")]
  public Guid StoreId { get; set; }

  [Column("member_id")]
  public Guid MemberId { get; set; }

  [Column("permission")]
  public int Permission { get; set; }

  [Column("accepted")]
  public bool Accepted { get; set; }

  [Column("created_at")]
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  [Column("updated_at")]
  public DateTime UpdatedAt { get; set; }

  public UserTable? User { get; set; }
  public StoreTable? Store { get; set; }

  public StoreMemberTable(Guid storeId, Guid memberId, DateTime updatedAt, int permission, bool accepted)
  {
    Permission = permission;
    StoreId = storeId;
    MemberId = memberId;
    UpdatedAt = updatedAt;
    Accepted = accepted;
  }
}
