using BAS24.Api.Constants;
using BAS24.Api.Entities.Stores;
using BAS24.Api.Enums;
using BAS24.Api.IRepositories;
using BAS24.Api.Utils;
using BAS24.Libs.CQRS.Commands;
using BAS24.Libs.Postgres;

namespace BAS24.Auth.Application.Commands.Stores.Handlers;

public class CreateStoreCommandHandler : ICommandHandler<CreateStoreCommand>
{
  private readonly IStoreRepository _repository;

  public CreateStoreCommandHandler(IStoreRepository repository)
  {
    _repository = repository;
  }

  public async Task HandleAsync(CreateStoreCommand command)
  {
    var memberId = GuidHelper.NewId;
    var entity = new StoreEntity(
      id: command.Id,
      ownerId: command.OwnerId,
      name: command.Name,
      description: command.Description,
      address: command.Address,
      phones: command.Phones,
      emails: command.Emails,
      tags: command.Tags,
      keyWords: command.KeyWords,
      categoryIds: command.CategoryIds,
      priceRating: Rating.None,
      storeRating: Rating.None,
      startWorkingTime: command.StartWorkingTime,
      endWorkingTime: command.EndWorkingTime,
      active: false,
      updatedAt: DateTime.UtcNow
    )
    {
      CreatedAt = DateTime.UtcNow,
      StoreMembers = new List<StoreMemberEntity>()
      {
        new (memberId.ToGuid(),
          command.Id,
          command.OwnerId,
          StoreMemberPermissions.Administration,
          DateTime.UtcNow,
          DateTime.UtcNow)
      }
    };
    await _repository.CreateStoreAsync(entity);
  }
}
