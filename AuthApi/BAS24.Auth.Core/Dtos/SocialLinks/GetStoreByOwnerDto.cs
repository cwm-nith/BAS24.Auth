namespace BAS24.Api.Dtos.SocialLinks;

public class GetStoreByOwnerDto
{
  public Guid OwnerId { get; set; }
  public Guid StoreId { get; set; }
  public bool IsActive { get; set; }

  public GetStoreByOwnerDto(Guid ownerId, Guid storeId, bool isActive)
  {
    OwnerId = ownerId;
    StoreId = storeId;
    IsActive = isActive;
  }
}
