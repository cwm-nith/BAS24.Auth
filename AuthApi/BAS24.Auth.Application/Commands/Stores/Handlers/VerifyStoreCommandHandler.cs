using BAS24.Api.IRepositories;
using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores.Handlers;

public class VerifyStoreCommandHandler:ICommandHandler<VerifyStoreCommand, Guid>
{
  private readonly IStoreRepository _repository;

  public VerifyStoreCommandHandler(IStoreRepository repository)
  {
    _repository = repository;
  }

  public async Task HandleAsync(VerifyStoreCommand command, Guid id)
  {
    await _repository.VerifyStoreAsync(id, command.OwnerId, command.Code);
  }
}
