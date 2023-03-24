using BAS24.Api.IRepositories;
using BAS24.Api.IServices;
using BAS24.Api.Kafka.Constants;
using BAS24.Api.Kafka.Models.Stores;
using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores.Handlers;

public class DeleteStoreCommandHandler:ICommandHandler<DeleteStoreCommand>
{
  private readonly IStoreRepository _storeRepository;
  private readonly IKafkaProducerService _producer;
  public DeleteStoreCommandHandler(IStoreRepository storeRepository, IKafkaProducerService producer)
  {
    _storeRepository = storeRepository;
    _producer = producer;
  }

  public async Task HandleAsync(DeleteStoreCommand command)
  {
    var data = new KafkaDeleteStoreModel()
    {
      Owner = command.OwnerId,
      StoreId = command.Id
    };
    await _storeRepository.DeleteStoreAsync(command.OwnerId, command.Id);
    await _producer.SendAsync(data, KafkaTopics.DeleteStore);
  }
}
