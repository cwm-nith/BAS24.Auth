using BAS24.Api.Dtos.Stores;
using BAS24.Api.IRepositories;
using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores.Handlers;

public class RemoveStoreMemberCommandHandler:ICommandHandler<RemoveStoreMemberCommand>
{
  private readonly IStoreRepository _storeRepository;

  public RemoveStoreMemberCommandHandler(IStoreRepository storeRepository)
  {
    _storeRepository = storeRepository;
  }

  public async Task HandleAsync(RemoveStoreMemberCommand command)
  {
    var cmd = new RemoveStoreMemberDto()
    {
      MemberId = command.MemberId,
      StoreId = command.StoreId,
      StoreMemberId = command.StoreMemberId
    };
    await _storeRepository.RemoveUserFromStoreAsync(cmd);
  }
}
