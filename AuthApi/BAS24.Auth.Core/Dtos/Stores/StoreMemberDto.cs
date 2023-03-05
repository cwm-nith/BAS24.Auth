namespace BAS24.Api.Dtos.Stores;

public class StoreMemberDto
{
  public Guid Id { get; set; }
  public Guid StoreId { get; set; }
  public Guid MemberId { get; set; }
  public int Permission { get; set; }
  public bool Accepted { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  public StoreMemberDto(Guid id,
    Guid storeId,
    Guid memberId,
    int permission,
    bool accepted,
    DateTime createdAt,
    DateTime updatedAt)
  {
    Id = id;
    StoreId = storeId;
    MemberId = memberId;
    Permission = permission;
    Accepted = accepted;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
  }
}
