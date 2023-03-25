using BAS24.Api.Constants;
using BAS24.Api.Entities.Stores;
using BAS24.Api.Enums;
using BAS24.Api.IRepositories;
using BAS24.Api.IServices;
using BAS24.Api.Kafka.Constants;
using BAS24.Api.Kafka.Models;
using BAS24.Api.Kafka.Models.Stores;
using BAS24.Api.Utils;
using BAS24.Libs.CQRS.Commands;
using BAS24.Libs.Postgres;

namespace BAS24.Auth.Application.Commands.Stores.Handlers;

public class CreateStoreCommandHandler : ICommandHandler<CreateStoreCommand>
{
  private readonly IStoreRepository _repository;
  private readonly IKafkaProducerService _producer;

  public CreateStoreCommandHandler(IStoreRepository repository, IKafkaProducerService producer)
  {
    _repository = repository;
    _producer = producer;
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
          DateTime.UtcNow,
          true)
      }
    };
    
    await _repository.CreateStoreAsync(entity);
    
    KafkaCreateStoreModel data = new ()
    {
      OwnerId = entity.OwnerId,
      Active = entity.Active,
      StoreId = entity.Id,
      Name = entity.Name
    };
    await _producer.SendAsync(data, KafkaTopics.CreateStore);
  }
}
