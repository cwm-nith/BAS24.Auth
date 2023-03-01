using BAS24.Api.Dtos.Stores;
using BAS24.Api.IRepositories;
using BAS24.Auth.Application.Queries.Stores;
using BAS24.Libs.CQRS.Queries;

namespace BAS24.Auth.Infrastructure.QueryHandlers.Stores;

public class GetStoresPageQueryHandler : IQueryHandler<GetStoresPageQuery, PagedResult<StoreDto>>
{
  private readonly IStoreRepository _repository;

  public GetStoresPageQueryHandler(IStoreRepository repository)
  {
    _repository = repository;
  }

  public async Task<PagedResult<StoreDto>>? HandleAsync(GetStoresPageQuery query)
  {
    var q = new GetStoresPageDto()
      { Page = query.Page, Results = query.Results, OwnerId = query.OwnerId };
    var data = await _repository.GetAllStoresAsync(q);
    return data.Map(StoreDto.FromEntity);
  }
}
