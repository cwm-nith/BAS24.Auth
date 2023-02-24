using BAS24.Api.Dtos.Users;
using BAS24.Api.IRepositories;
using BAS24.Auth.Application.Queries.Users;
using BAS24.Libs.CQRS.Queries;

namespace BAS24.Auth.Infrastructure.QueryHandlers.Users;

public class GetUserPageQueryHandler : IQueryHandler<GetUserPageQuery, PagedResult<UserDto>>
{
  private readonly IUserRepository _repository;

  public GetUserPageQueryHandler(IUserRepository repository)
  {
    _repository = repository;
  }

  public async Task<PagedResult<UserDto>>? HandleAsync(GetUserPageQuery query)
  {
    var q = await _repository.GetUserPaginate(new PagedQuery { Page = query.Page, Results = query.Results });
    return q.Map(UserDto.FromEntity);
  }
}
