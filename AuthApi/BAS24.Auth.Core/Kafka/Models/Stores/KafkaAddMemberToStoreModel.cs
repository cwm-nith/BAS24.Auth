namespace BAS24.Api.Kafka.Models.Stores;

public class KafkaAddMemberToStoreModel
{
  public Guid StoreId { get; set; }
  public Guid MemberId { get; set; }
  public Guid OwnerId { get; set; }
  public int Permission { get; set; }
}
