using BAS24.Api.Dtos.Users;
using BAS24.Libs.CQRS.Queries;

namespace BAS24.Auth.Application.Queries.Users;

public class GetUserByIdQuery:IQuery<UserDto>
{
  public string Id { get; set; }

  public GetUserByIdQuery(string id)
  {
    Id = id;
  }
}
