using BAS24.Api.Entities.User;
using BAS24.Api.Exceptions.Users;
using BAS24.Api.IRepositories;
using BAS24.Libs.CQRS.Commands;
using Microsoft.AspNetCore.Identity;

namespace BAS24.Auth.Application.Commands.Users.Handlers;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
{
  private readonly IPasswordHasher<UserEntity> _passwordHasher;
  private readonly IUserRepository _repository;

  public CreateUserCommandHandler(IUserRepository repository, IPasswordHasher<UserEntity> passwordHasher)
  {
    _repository = repository;
    _passwordHasher = passwordHasher;
    // _event = @event;
  }

  public async Task HandleAsync(CreateUserCommand command)
  {
    var user = await _repository.GetActiveUserByUsername(command.Username);
    if (user is { })
    {
      throw new ExistedUsernameException();
    }

    var entity = new UserEntity(username: command.Username)
    {
      Id = command.Id,
      CreatedAt = DateTime.UtcNow,
      Fullname = command.Fullname,
      Active = true,
      Address = command.Address,
      IsLock = false,
      IsApprove = false,
      UpdatedAt = DateTime.UtcNow,
      RegionName = command.RegionName
    };
    entity.SetPhone(command.Phones ?? Array.Empty<string>());
    entity.SetPassword(command.Password, _passwordHasher);
    await _repository.CreateUser(entity);
  }
}
