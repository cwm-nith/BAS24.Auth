namespace BAS24.Product.Core.IRepositories;

public interface IKafkaConsumerRepository
{
  Task CreateStoreConsumerAsync(string groupId, string topic, CancellationToken cancellationToken);
  Task UpdateStoreConsumerAsync(string groupId, string topic, CancellationToken cancellationToken);
  Task DeleteStoreConsumerAsync(string groupId, string topic, CancellationToken cancellationToken);
  Task RemoveStoreMemberConsumerAsync(string groupId, string topic, CancellationToken cancellationToken);
  Task UpdateStoreMemberConsumerAsync(string groupId, string topic, CancellationToken cancellationToken);
  Task AddStoreMemberConsumerAsync(string groupId, string topic, CancellationToken cancellationToken);
}
