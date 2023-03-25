using BAS24.Product.Core.IServices;
using BAS24.Product.Core.Kafka.Constants;
using BAS24.Product.Core.Kafka.Models.Stores;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BAS24.Product.Infrastructure.Services;

public class KafkaConsumerService:IKafkaConsumerService
{
  private readonly IConfiguration _configuration;
  private readonly ILogger<KafkaConsumerService> _logger;

  public KafkaConsumerService(IConfiguration configuration, ILogger<KafkaConsumerService> logger)
  {
    _configuration = configuration;
    _logger = logger;
  }

  public Task Subscribe<>(string groupId, string topic, CancellationToken cancellationToken)
  {
    var config = new ConsumerConfig
    {
      GroupId = groupId,
      BootstrapServers = _configuration["Kafka:BootstrapServers"],
      AutoOffsetReset = AutoOffsetReset.Earliest
    };

    try
    {
      using var consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build();
      consumerBuilder.Subscribe(topic);
      try
      {
        while (true)
        {
          var consumer = consumerBuilder.Consume(cancellationToken);
          var orderRequest = JsonConvert.DeserializeObject<KafkaCreateStoreModel>(consumer.Message.Value);
          _logger.LogInformation($"{groupId}: {orderRequest?.StoreId} {DateTime.Now}");
        }
      }
      catch (OperationCanceledException)
      {
        consumerBuilder.Close();
      }
    }
    catch (Exception ex)
    {
      _logger.LogError(ex.Message);
    }

    return Task.CompletedTask;
  }
}
