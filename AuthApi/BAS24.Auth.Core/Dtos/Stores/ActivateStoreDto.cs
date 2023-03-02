namespace BAS24.Api.Dtos.Stores;

public class ActivateStoreDto
{
  public Guid Id { get; set; }
  public Guid OwnerId { get; set; }

  public ActivateStoreDto(Guid id, Guid ownerId)
  {
    Id = id;
    OwnerId = ownerId;
  }
}
