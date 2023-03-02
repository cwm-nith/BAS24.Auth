using BAS24.Api.Dtos.SocialLinks;
using BAS24.Api.Dtos.Stores;
using BAS24.Api.Exceptions.Stores;
using BAS24.Api.IRepositories;
using BAS24.Auth.Application.Queries.Stores;
using BAS24.Libs.CQRS.Queries;

namespace BAS24.Auth.Infrastructure.QueryHandlers.Stores;

public class GetStoreByIdAndOwnerIdQueryHandler:IQueryHandler<GetStoreByIdAndOwnerIdQuery, StoreDto>
{
  private readonly IStoreRepository _repository;

  public GetStoreByIdAndOwnerIdQueryHandler(IStoreRepository repository)
  {
    _repository = repository;
  }

  public async Task<StoreDto> HandleAsync(GetStoreByIdAndOwnerIdQuery query)
  {
    var q = new GetStoreByOwnerDto(query.OwnerId, query.Id, query.IsActive);
    var store = await _repository.GetStoreByOwnerAsync(q);
    if (store is null) throw new StoreNotFoundException();
    return StoreDto.FromEntity(store);
  }
}
