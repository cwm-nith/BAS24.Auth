using BAS24.Api.IRepositories;
using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores.Handlers;

public class DeactivateStoreCommandHandler:ICommandHandler<DeactivateStoreCommand, Guid>
{
  private readonly IStoreRepository _storeRepository;

  public DeactivateStoreCommandHandler(IStoreRepository storeRepository)
  {
    _storeRepository = storeRepository;
  }

  public async Task HandleAsync(DeactivateStoreCommand command, Guid id)
  {
    await _storeRepository.DeactivateStoreAsync(command.OwnerId, id);
  }
}
