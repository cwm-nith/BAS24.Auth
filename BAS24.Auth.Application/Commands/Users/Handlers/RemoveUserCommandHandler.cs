using BAS24.Api.Exceptions.Users;
using BAS24.Api.IRepositories;
using BAS24.Libs.CQRS.Commands;

namespace Application.Commands.Users.Handlers;

public class RemoveUserCommandHandler : ICommandHandler<RemoveUserCommand, Guid>
{
  private readonly IUserRepository _repository;

  public RemoveUserCommandHandler(IUserRepository repository)
  {
    _repository = repository;
  }

  public async Task HandleAsync(RemoveUserCommand command, Guid id)
  {
    var user = await _repository.GetUserById(id);
    if (user == null)
    {
      throw new UserNotFoundException(id.ToString());
    }

    await _repository.RemoveUserById(id);
  }
}
