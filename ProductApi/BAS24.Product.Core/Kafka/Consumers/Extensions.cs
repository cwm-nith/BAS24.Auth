using BAS24.Product.Core.Kafka.Consumers.Stores;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BAS24.Product.Core.Kafka.Consumers;

public static class Extensions
{
  public static IServiceCollection AddKafkaConsumer(this IServiceCollection services)
  {
    services.AddSingleton<IHostedService, CreateStoreConsumer>();
    return services;
  }
}
