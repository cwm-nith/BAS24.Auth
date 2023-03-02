using BAS24.Api.IRepositories;
using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores.Handlers;

public class ActivateStoreCommandHandler: ICommandHandler<ActivateStoreCommand, Guid>
{
  private readonly IStoreRepository _storeRepository;

  public ActivateStoreCommandHandler(IStoreRepository storeRepository)
  {
    _storeRepository = storeRepository;
  }
  public async Task HandleAsync(ActivateStoreCommand command, Guid id)
  {
    await _storeRepository.ActivateStoreAsync(command.OwnerId, id);
  }
}
