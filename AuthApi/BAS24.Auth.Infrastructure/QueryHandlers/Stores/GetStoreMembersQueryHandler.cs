using BAS24.Api.Dtos.Stores;
using BAS24.Api.IRepositories;
using BAS24.Auth.Application.Queries.Stores;
using BAS24.Auth.Infrastructure.Postgres.Store;
using BAS24.Libs.CQRS.Queries;

namespace BAS24.Auth.Infrastructure.QueryHandlers.Stores;

public class GetStoreMembersQueryHandler:IQueryHandler<GetStoreMembersQuery, PagedResult<StoreMemberDto>>
{
  private readonly IStoreRepository _storeRepository;

  public GetStoreMembersQueryHandler(IStoreRepository storeRepository)
  {
    _storeRepository = storeRepository;
  }

  public async Task<PagedResult<StoreMemberDto>> HandleAsync(GetStoreMembersQuery query)
  {
    var q = new GetStoreMembersDto()
    {
      Results = query.Results,
      StoreId = query.StoreId,
      Page = query.Page,
      Filter = query.Filter
    };
    var data = await _storeRepository
      .GetStoreMembersAsync(q);
    return data.Map(i => i.AsDto());
  }
}
