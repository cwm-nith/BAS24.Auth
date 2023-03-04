using BAS24.Api.IRepositories;
using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Users.Handlers;

public class VerifyCodeCommandHandler : ICommandHandler<VerifyCodeCommand>
{
  private readonly IUserRepository _repository;

  public VerifyCodeCommandHandler(IUserRepository repository)
  {
    _repository = repository;
  }

  public async Task HandleAsync(VerifyCodeCommand command)
  {
    await _repository.VerifyCodeAsync(command.Code, command.To);
  }
}
