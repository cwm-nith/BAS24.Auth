using BAS24.Product.Core.IRepositories;
using BAS24.Product.Core.Kafka.Models.Stores;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BAS24.Product.Infrastructure.Repositories;

public class KafkaConsumerRepository:IKafkaConsumerRepository
{
  private readonly IConfiguration _configuration;
  private readonly ILogger<KafkaConsumerRepository> _logger;

  public KafkaConsumerRepository(IConfiguration configuration, ILogger<KafkaConsumerRepository> logger)
  {
    _configuration = configuration;
    _logger = logger;
  }
  public Task CreateStoreConsumerAsync(string groupId, string topic, CancellationToken cancellationToken)
  {
    try
    {
      var config = GetKafkaConsumerConfig(groupId);
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

  public Task UpdateStoreConsumerAsync(string groupId, string topic, CancellationToken cancellationToken)
  {
    try
    {
      var config = GetKafkaConsumerConfig(groupId);
      using var consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build();
      consumerBuilder.Subscribe(topic);
      try
      {
        while (true)
        {
          var consumer = consumerBuilder.Consume(cancellationToken);
          var data = JsonConvert.DeserializeObject<KafkaUpdateStoreModel>(consumer.Message.Value);
          _logger.LogInformation($"{groupId}: {data?.Name}, {data?.StoreId}, {DateTime.Now}");
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

  public Task DeleteStoreConsumerAsync(string groupId, string topic, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task RemoveStoreMemberConsumerAsync(string groupId, string topic, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task UpdateStoreMemberConsumerAsync(string groupId, string topic, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task AddStoreMemberConsumerAsync(string groupId, string topic, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  private ConsumerConfig GetKafkaConsumerConfig(string groupId)
  {
    return new ()
    {
      GroupId = groupId,
      BootstrapServers = _configuration["Kafka:BootstrapServers"],
      AutoOffsetReset = AutoOffsetReset.Earliest
    };
  }
}
