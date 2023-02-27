using BAS24.Api.Dtos.Users;
using BAS24.Api.Exceptions.Users;
using BAS24.Api.IRepositories;
using BAS24.Auth.Application.Queries.Users;
using BAS24.Libs.CQRS.Queries;
using BAS24.Libs.Postgres;

namespace BAS24.Auth.Infrastructure.QueryHandlers.Users;

public class GetUserByIdQueryHandler:IQueryHandler<GetUserByIdQuery, UserDto>
{
  private readonly IUserRepository _repository;

  public GetUserByIdQueryHandler(IUserRepository repository)
  {
    _repository = repository;
  }

  public async Task<UserDto> HandleAsync(GetUserByIdQuery query)
  {
    var user = await _repository.GetUserById(query.Id.ToGuid());
    if (user is null) throw new UserNotFoundException(query.Id);
    return UserDto.FromEntity(user);
  }
}
