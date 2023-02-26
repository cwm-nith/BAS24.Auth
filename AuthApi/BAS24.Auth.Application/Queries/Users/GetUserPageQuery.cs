using BAS24.Api.Dtos.Users;
using BAS24.Libs.CQRS.Queries;

namespace BAS24.Auth.Application.Queries.Users;

public class GetUserPageQuery : IQuery<PagedResult<UserDto>>
{
  public int Page { get; set; }
  public int Results { get; set; }
}
