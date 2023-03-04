using BAS24.Api.Dtos.Stores;
using BAS24.Api.IRepositories;
using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores.Handlers;

public class UpdateRoleOfStoreMemberCommandHandler : ICommandHandler<UpdateRoleOfStoreMemberCommand, Guid>
{
  private readonly IStoreRepository _repository;

  public UpdateRoleOfStoreMemberCommandHandler(IStoreRepository repository)
  {
    _repository = repository;
  }

  public async Task HandleAsync(UpdateRoleOfStoreMemberCommand command, Guid id)
  {
    var dto = new UpdateRoleOfStoreMemberDto()
    {
      StoreId = command.StoreId,
      MemberStoreId = command.StoreMemberId,
      Permission = command.Permission
    };
    await _repository.UpdateUserStoreRoleAsync(id, dto);
  }
}
