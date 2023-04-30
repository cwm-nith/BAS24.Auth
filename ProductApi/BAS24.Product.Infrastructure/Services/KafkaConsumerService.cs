using BAS24.Product.Core.Exceptions;
using BAS24.Product.Core.IRepositories;
using BAS24.Product.Core.IServices;
using BAS24.Product.Core.Kafka.Constants;

namespace BAS24.Product.Infrastructure.Services;

public class KafkaConsumerService:IKafkaConsumerService
{
  private readonly IKafkaConsumerRepository _consumerRepository;

  public KafkaConsumerService(IKafkaConsumerRepository consumerRepository)
  {
    _consumerRepository = consumerRepository;
  }

  public Task SubscribeAsync(string topic, CancellationToken cancellationToken)
  {

    switch (topic)
    {
      case var _ when KafkaTopics.CreateStore == topic:
        _consumerRepository.CreateStoreConsumerAsync(KafkaGroupIds.CreateStore, topic, cancellationToken);
        break;
      case var _ when KafkaTopics.UpdateStore == topic:
        _consumerRepository.UpdateStoreConsumerAsync(KafkaGroupIds.UpdateStore, topic, cancellationToken);
        break;
      default:
        throw new KafkaTopicInvalidException();
    }

    return Task.CompletedTask;
  }
}
