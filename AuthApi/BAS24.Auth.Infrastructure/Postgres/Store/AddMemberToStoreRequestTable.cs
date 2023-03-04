using System.ComponentModel.DataAnnotations.Schema;
using BAS24.Auth.Infrastructure.Postgres.User;
using BAS24.Libs.Postgres;

namespace BAS24.Auth.Infrastructure.Postgres.Store;

[Table("add_member_to_store_requests")]
public class AddMemberToStoreRequestTable : BasePostgresTable
{
  [Column("store_id")]
  public Guid StoreId { get; set; }
  [Column("store_member_id")]
  public Guid StoreMemberId { get; set; }
  [Column("member_id")]
  public Guid MemberId { get; set; }
  [Column("by_id")]
  public Guid ById { get; set; }
  [Column("subject")]
  public string Subject { get; set; }
  [Column("description")]
  public string Description { get; set; }
  [Column("by")]
  public string By { get; set; }
  [Column("created_at")]
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  [Column("updated_at")]
  public DateTime UpdatedAt { get; set; }

  public StoreTable? Store { get; set; }
  public StoreMemberTable? StoreMember { get; set; }
  public UserTable? Member { get; set; }
  public UserTable? ByUser { get; set; }
  

  public AddMemberToStoreRequestTable(Guid storeId,
    Guid storeMemberId,
    Guid memberId,
    Guid byId,
    string subject,
    string description,
    string by,
    DateTime updatedAt)
  {
    StoreId = storeId;
    StoreMemberId = storeMemberId;
    MemberId = memberId;
    ById = byId;
    Subject = subject;
    Description = description;
    By = by;
    UpdatedAt = updatedAt;
  }
}
