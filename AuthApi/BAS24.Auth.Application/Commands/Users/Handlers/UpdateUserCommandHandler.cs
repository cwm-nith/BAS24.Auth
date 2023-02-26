using BAS24.Api.Exceptions.Users;
using BAS24.Api.IRepositories;
using BAS24.Libs.CQRS.Commands;

namespace Application.Commands.Users.Handlers;

public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, Guid>
{
  private readonly IUserRepository _repository;

  public UpdateUserCommandHandler(IUserRepository repository)
  {
    _repository = repository;
  }

  public async Task HandleAsync(UpdateUserCommand command, Guid id)
  {
    var existUn = await _repository.GetActiveUserByUsername(command.Username ?? "");

    if (existUn is { } && existUn.Id != id)
    {
      throw new ExistedUsernameException();
    }

    var user = await _repository.GetUserById(id);
    if (user == null)
    {
      throw new UserNotFoundException(id.ToString());
    }

    user.Username = command.Username ?? user.Username;
    user.Address = command.Address ?? user.Address;
    user.Fullname = command.Fullname ?? user.Fullname;
    user.RegionName = command.RegionName ?? user.RegionName;
    user.UpdatedAt = DateTime.UtcNow;
    user.SetPhone(command.Phones);

    await _repository.UpdateUser(user);
  }
}
