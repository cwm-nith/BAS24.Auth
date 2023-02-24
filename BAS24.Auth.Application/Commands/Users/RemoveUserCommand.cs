using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Users;

public class RemoveUserCommand : ICommand
{
  public RemoveUserCommand(Guid userId)
  {
    UserId = userId;
  }

  public Guid UserId { get; set; }
}
