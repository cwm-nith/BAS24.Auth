using BAS24.Auth.Infrastructure.Migrations;
using BAS24.Libs.Postgres;

namespace BAS24.Auth.Infrastructure.Postgres.Store;

public class AddMemberToStoreRequestTable : BasePostgresTable
{
  public Guid StoreId { get; set; }
  public Guid StoreMemberId { get; set; }
  public Guid MemberId { get; set; }
  public Guid ById { get; set; }
  public string Subject { get; set; }
  public string Description { get; set; }
  public string By { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; }

  public StoreTable? Store { get; set; }
  public StoreMemberTable? StoreMember { get; set; }
  public UserTable Member { get; set; }
  

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
