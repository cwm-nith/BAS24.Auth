using BAS24.Product.Core.Kafka.Models;

namespace BAS24.Product.Core.IServices;

public interface IKafkaConsumerService
{
  Task SubscribeAsync(string topic, CancellationToken cancellationToken);
}
