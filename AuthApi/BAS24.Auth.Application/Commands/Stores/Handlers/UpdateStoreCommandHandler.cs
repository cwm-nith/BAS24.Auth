using BAS24.Api.Dtos.SocialLinks;
using BAS24.Api.Entities.Stores;
using BAS24.Api.Exceptions.Stores;
using BAS24.Api.IRepositories;
using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores.Handlers;

public class UpdateStoreCommandHandler:ICommandHandler<UpdateStoreCommand>
{
  private readonly IStoreRepository _storeRepository;

  public UpdateStoreCommandHandler(IStoreRepository storeRepository)
  {
    _storeRepository = storeRepository;
  }

  public async Task HandleAsync(UpdateStoreCommand command)
  {
    var storeQuery = new GetStoreByOwnerDto(command.OwnerId, command.Id, true);
    var entity = await _storeRepository
      .GetStoreByOwnerAsync(storeQuery);
    if (entity is null) throw new StoreNotFoundException();
    entity.Name = command.Name;
    entity.Address = command.Address;
    entity.Description = command.Description;
    entity.Emails = command.Emails;
    entity.Phones = command.Phones;
    entity.Tags = command.Tags;
    entity.KeyWords = command.KeyWords;
    entity.UpdatedAt = DateTime.UtcNow;
    await _storeRepository.UpdateStoreAsync(entity);
  }
}
