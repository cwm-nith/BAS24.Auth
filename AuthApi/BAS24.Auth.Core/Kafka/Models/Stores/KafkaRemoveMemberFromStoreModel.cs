namespace BAS24.Api.Kafka.Models.Stores;

public class KafkaRemoveMemberFromStoreModel
{
  public Guid StoreId { get; set; }
  public Guid MemberId { get; set; }
  public Guid StoreMemberId { get; set; }
}
