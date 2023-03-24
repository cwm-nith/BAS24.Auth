using System.Diagnostics;
using System.Net;
using BAS24.Auth.Infrastructure.Services.Interfaces;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BAS24.Auth.Infrastructure.Services;

public class KafkaProducerServiceService : IKafkaProducerService
{
  private readonly IConfiguration _configuration;

  public KafkaProducerServiceService(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  public async Task<bool> SendAsync<T>(T data, string topic) where T : class
  {
    ProducerConfig config = new()
    {
      BootstrapServers = _configuration["Kafka:BootstrapServers"],
      ClientId = Dns.GetHostName()
    };

    try
    {
      using var producer = new ProducerBuilder<Null, string>(config).Build();
      var message = JsonConvert.SerializeObject(data);
      var result = await producer.ProduceAsync(topic,
        new Message<Null, string>
        {
          Value = message
        });

      Debug.WriteLine($"Delivery Timestamp:{result.Timestamp.UtcDateTime}");
      return await Task.FromResult(true);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error occured: {ex.Message}");
    }

    return await Task.FromResult(false);
  }
}
