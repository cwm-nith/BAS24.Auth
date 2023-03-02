using BAS24.Api.Dtos.Stores;
using BAS24.Libs.CQRS.Queries;

namespace BAS24.Auth.Application.Queries.Stores;

public class GetStoreByIdAndOwnerIdQuery:IQuery<StoreDto>
{
  public Guid Id { get; set; }
  public Guid OwnerId { get; set; }
  public bool IsActive { get; set; }

  public GetStoreByIdAndOwnerIdQuery(Guid id, Guid ownerId, bool isActive)
  {
    Id = id;
    OwnerId = ownerId;
    IsActive = isActive;
  }
}
