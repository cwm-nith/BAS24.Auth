using System.Diagnostics;
using BAS24.Product.Core.Kafka.Constants;
using BAS24.Product.Core.Kafka.Models.Stores;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BAS24.Product.Core.Kafka.Consumers.Stores;

public class CreateStoreConsumer : IHostedService
{
  private readonly IConfiguration _configuration;
  private readonly ILogger<CreateStoreConsumer> _logger;

  public CreateStoreConsumer(IConfiguration configuration, ILogger<CreateStoreConsumer> logger)
  {
    _configuration = configuration;
    _logger = logger;
  }

  public Task StartAsync(CancellationToken cancellationToken)
  {
    var config = new ConsumerConfig
    {
      GroupId = KafkaGroupIds.CreateStore,
      BootstrapServers = _configuration["Kafka:BootstrapServers"],
      AutoOffsetReset = AutoOffsetReset.Earliest
    };

    try
    {
      using var consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build();
      consumerBuilder.Subscribe(KafkaTopics.CreateStore);
      try
      {
        while (true)
        {
          var consumer = consumerBuilder.Consume(cancellationToken);
          var orderRequest = JsonConvert.DeserializeObject<KafkaCreateStoreModel>(consumer.Message.Value);
          Debug.WriteLine($"Processing create store Id: {orderRequest?.StoreId} {DateTime.Now}");
          _logger.LogInformation($"Processing create store Id: {orderRequest?.StoreId} {DateTime.Now}");
        }
      }
      catch (OperationCanceledException)
      {
        consumerBuilder.Close();
      }
    }
    catch (Exception ex)
    {
      Debug.WriteLine(ex.Message);
      _logger.LogError(ex.Message);
    }
    return Task.CompletedTask;
  }

  public Task StopAsync(CancellationToken cancellationToken)
  {
    return Task.CompletedTask;
  }
}
