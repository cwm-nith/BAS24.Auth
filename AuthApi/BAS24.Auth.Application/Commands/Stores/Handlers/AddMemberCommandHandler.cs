using BAS24.Api.Dtos.Stores;
using BAS24.Api.IRepositories;
using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores.Handlers;

public class AddMemberCommandHandler : ICommandHandler<AddMemberCommand, Guid>
{
  private readonly IStoreRepository _storeRepository;

  public AddMemberCommandHandler(IStoreRepository storeRepository)
  {
    _storeRepository = storeRepository;
  }

  public async Task HandleAsync(AddMemberCommand command, Guid id)
  {
    var cmd = new AddMemberDto()
    {
      Permission = command.Permission,
      MemberId = command.MemberId,
      StoreId = command.StoreId,
    };
    await _storeRepository.AddUserToStoreAsync(id, cmd);
  }
}
