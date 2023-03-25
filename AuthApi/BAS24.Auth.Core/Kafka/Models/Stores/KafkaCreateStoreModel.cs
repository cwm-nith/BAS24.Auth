namespace BAS24.Api.Kafka.Models.Stores;

public class KafkaCreateStoreModel
{
  public Guid StoreId { get; set; }
  public Guid OwnerId { get; set; }
  public bool Active { get; set; }
  public string Name { get; set; } = string.Empty;
}
