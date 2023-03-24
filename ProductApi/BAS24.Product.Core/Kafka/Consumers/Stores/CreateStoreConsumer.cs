using System.Diagnostics;
using BAS24.Product.Core.Kafka.Constants;
using BAS24.Product.Core.Kafka.Models.Stores;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace BAS24.Product.Core.Kafka.Consumers.Stores;

public class CreateStoreConsumer : IHostedService
{
  private readonly IConfiguration _configuration;

  public CreateStoreConsumer(IConfiguration configuration)
  {
    _configuration = configuration;
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
      var cancelToken = new CancellationTokenSource();
      try
      {
        while (true)
        {
          var consumer = consumerBuilder.Consume
            (cancelToken.Token);
          var orderRequest = JsonConvert.DeserializeObject<KafkaCreateStoreModel>(consumer.Message.Value);
          Debug.WriteLine($"Processing create store Id: {orderRequest?.StoreId}");
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
    }
    return Task.CompletedTask;
  }

  public Task StopAsync(CancellationToken cancellationToken)
  {
    return Task.CompletedTask;
  }
}
