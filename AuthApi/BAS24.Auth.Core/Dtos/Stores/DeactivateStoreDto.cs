namespace BAS24.Api.Dtos.Stores;

public class DeactivateStoreDto
{
  public Guid Id { get; set; }
  public Guid OwnerId { get; set; }

  public DeactivateStoreDto(Guid id, Guid ownerId)
  {
    Id = id;
    OwnerId = ownerId;
  }
}
