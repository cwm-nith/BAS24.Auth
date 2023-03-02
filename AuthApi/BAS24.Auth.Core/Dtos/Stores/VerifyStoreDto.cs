namespace BAS24.Api.Dtos.Stores;

public class VerifyStoreDto
{
  public Guid Id { get; set; }
  public Guid OwnerId { get; set; }
  public string Code { get; set; }

  public VerifyStoreDto(Guid id, Guid ownerId, string code)
  {
    Id = id;
    OwnerId = ownerId;
    Code = code;
  }
}
