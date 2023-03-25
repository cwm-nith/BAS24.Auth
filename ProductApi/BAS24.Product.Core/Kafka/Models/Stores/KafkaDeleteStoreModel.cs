namespace BAS24.Product.Core.Kafka.Models.Stores;

public class KafkaDeleteStoreModel:IBaseKafkaModel
{
  public Guid StoreId { get; set; }
  public Guid Owner { get; set; }
}
