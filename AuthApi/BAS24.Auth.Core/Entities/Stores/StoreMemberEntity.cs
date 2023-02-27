using BAS24.Api.Entities.User;
using BAS24.Api.Enums;

namespace BAS24.Api.Entities.Stores;

public class StoreMemberEntity
{
  public Guid Id { get; set; }
  public Guid StoreId { get; set; }
  public Guid MemberId { get; set; }
  public StoreMemberRoles StoreMemberRole { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  public UserEntity? User { get; set; }
  public StoreEntity? Store { get; set; }

  public StoreMemberEntity(Guid id,
    Guid storeId,
    Guid memberId,
    StoreMemberRoles storeMemberRole,
    DateTime createdAt,
    DateTime updatedAt)
  {
    Id = id;
    StoreId = storeId;
    MemberId = memberId;
    StoreMemberRole = storeMemberRole;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
  }
}
