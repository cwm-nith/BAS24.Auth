namespace BAS24.Product.Core.Kafka.Models.Stores;

public class KafkaCreateStoreModel:IBaseKafkaModel
{
  public Guid StoreId { get; set; }
  public Guid OwnerId { get; set; }
  public bool Active { get; set; }
  public string Name { get; set; } = string.Empty;
}
