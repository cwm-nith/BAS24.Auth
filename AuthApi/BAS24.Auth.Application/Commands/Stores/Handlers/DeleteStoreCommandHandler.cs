using BAS24.Api.IRepositories;
using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores.Handlers;

public class DeleteStoreCommandHandler:ICommandHandler<DeleteStoreCommand>
{
  private readonly IStoreRepository _storeRepository;

  public DeleteStoreCommandHandler(IStoreRepository storeRepository)
  {
    _storeRepository = storeRepository;
  }

  public async Task HandleAsync(DeleteStoreCommand command)
  {
    await _storeRepository.DeleteStoreAsync(command.OwnerId, command.Id);
  }
}
