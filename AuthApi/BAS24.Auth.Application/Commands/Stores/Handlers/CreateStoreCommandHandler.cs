using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores.Handlers;

public class CreateStoreCommandHandler:ICommandHandler<CreateStoreCommand>
{
  public Task HandleAsync(CreateStoreCommand command)
  {
    throw new NotImplementedException();
  }
}
