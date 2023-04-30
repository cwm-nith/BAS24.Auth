using BAS24.Product.Core.IServices;
using BAS24.Product.Core.Kafka.Constants;
using Microsoft.Extensions.Hosting;

namespace BAS24.Product.Core.Kafka.Consumers.Stores;

public class CreateStoreConsumer : IHostedService
{
  private readonly IKafkaConsumerService _consumerService;

  public CreateStoreConsumer(IKafkaConsumerService consumerService)
  {
    _consumerService = consumerService;
  }

  public async Task StartAsync(CancellationToken cancellationToken)
  {
    await _consumerService.SubscribeAsync(KafkaTopics.CreateStore, cancellationToken);
  }

  public Task StopAsync(CancellationToken cancellationToken)
  {
    return Task.CompletedTask;
  }
}
