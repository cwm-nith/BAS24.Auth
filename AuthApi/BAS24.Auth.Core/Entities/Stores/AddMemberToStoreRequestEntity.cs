using BAS24.Api.Entities.User;

namespace BAS24.Api.Entities.Stores;

public class AddMemberToStoreRequestEntity
{
  public Guid Id { get; set; }
  public Guid StoreId { get; set; }
  public Guid StoreMemberId { get; set; }
  public Guid MemberId { get; set; }
  public Guid ById { get; set; }
  public string Subject { get; set; }
  public string Description { get; set; }
  public string By { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  public StoreEntity? Store { get; set; }
  public StoreMemberEntity? StoreMember { get; set; }
  public UserEntity? Member { get; set; }
  public UserEntity? ByUser { get; set; }

  public AddMemberToStoreRequestEntity(Guid id,
    Guid storeId,
    Guid storeMemberId,
    Guid memberId,
    Guid byId,
    string subject,
    string description,
    string by,
    DateTime createdAt,
    DateTime updatedAt)
  {
    Id = id;
    StoreId = storeId;
    StoreMemberId = storeMemberId;
    MemberId = memberId;
    ById = byId;
    Subject = subject;
    Description = description;
    By = by;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
  }
}
