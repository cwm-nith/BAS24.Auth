namespace BAS24.Product.Core.Kafka.Models.Stores;

public class KafkaRemoveMemberFromStoreModel
{
  public Guid StoreId { get; set; }
  public Guid MemberId { get; set; }
  public Guid StoreMemberId { get; set; }
}
