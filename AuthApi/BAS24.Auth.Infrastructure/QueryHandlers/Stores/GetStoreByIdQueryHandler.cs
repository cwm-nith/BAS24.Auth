using BAS24.Api.Dtos.Stores;
using BAS24.Api.Exceptions.Stores;
using BAS24.Api.IRepositories;
using BAS24.Auth.Application.Queries.Stores;
using BAS24.Libs.CQRS.Queries;

namespace BAS24.Auth.Infrastructure.QueryHandlers.Stores;

public class GetStoreByIdQueryHandler:IQueryHandler<GetStoreByIdQuery, StoreDto>
{
  private readonly IStoreRepository _repository;

  public GetStoreByIdQueryHandler(IStoreRepository repository)
  {
    _repository = repository;
  }

  public async Task<StoreDto> HandleAsync(GetStoreByIdQuery query)
  {
    var store = await _repository.GetStoreByIdAsync(query.Id, query.IsActive);
    if (store is null) throw new StoreNotFoundException();
    return StoreDto.FromEntity(store);
  }
}
