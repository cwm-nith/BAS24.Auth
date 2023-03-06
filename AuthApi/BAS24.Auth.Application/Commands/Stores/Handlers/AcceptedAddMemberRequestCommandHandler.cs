using BAS24.Api.Dtos.Stores;
using BAS24.Api.IRepositories;
using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores.Handlers;

public class AcceptedAddMemberRequestCommandHandler : ICommandHandler<AcceptedAddMemberRequestCommand>
{
  private readonly IStoreRepository _storeRepository;

  public AcceptedAddMemberRequestCommandHandler(IStoreRepository storeRepository)
  {
    _storeRepository = storeRepository;
  }

  public async Task HandleAsync(AcceptedAddMemberRequestCommand command)
  {
    var cmd = new AcceptedAddMemberRequestDto()
    {
      StoreId = command.StoreId,
      StoreMemberId = command.StoreMemberId,
    };
    await _storeRepository.AcceptedAddMemberRequest(cmd, command.MemberId);
  }
}
