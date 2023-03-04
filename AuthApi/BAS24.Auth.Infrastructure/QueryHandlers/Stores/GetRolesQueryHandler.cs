using BAS24.Api.Dtos.Stores;
using BAS24.Api.IRepositories;
using BAS24.Auth.Application.Queries.Stores;
using BAS24.Libs.CQRS.Queries;

namespace BAS24.Auth.Infrastructure.QueryHandlers.Stores;

public class GetRolesQueryHandler:IQueryHandler<GetRolesQuery, List<RoleDto>>
{
  private readonly IStoreRepository _storeRepository;

  public GetRolesQueryHandler(IStoreRepository storeRepository)
  {
    _storeRepository = storeRepository;
  }

  public async Task<List<RoleDto>>? HandleAsync(GetRolesQuery query)
  {
    var roles = _storeRepository.GetRoles();
    return await Task.FromResult(roles);
  }
}
