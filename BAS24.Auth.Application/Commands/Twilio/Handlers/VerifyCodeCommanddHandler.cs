using BAS24.Api.IRepositories;
using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Twilio.Handlers;

public class VerifyCodeCommandHandler : ICommandHandler<VerifyCodeCommand, string>
{
  private readonly ITwilioRepository _repository;

  public VerifyCodeCommandHandler(ITwilioRepository repository)
  {
    _repository = repository;
  }

  public async Task HandleAsync(VerifyCodeCommand command, string id)
  {
    await _repository.VerifyCodeAsync(command.Code, id);
  }
}
