namespace BAS24.Product.Core.Kafka.Models.Stores;

public class KafkaUpdateStoreModel:IBaseKafkaModel
{
  public string Name { get; set; } = string.Empty;
  public bool Active { get; set; }
  public Guid StoreId { get; set; }
}
