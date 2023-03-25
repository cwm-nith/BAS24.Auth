namespace BAS24.Product.Core.IServices;

public interface IKafkaConsumerService
{
  Task Subscribe(string groupId, string topic, CancellationToken cancellationToken);
}
