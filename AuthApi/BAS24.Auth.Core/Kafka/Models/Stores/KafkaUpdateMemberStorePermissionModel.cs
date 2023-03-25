namespace BAS24.Api.Kafka.Models.Stores;

public class KafkaUpdateMemberStorePermissionModel
{
  public Guid StoreId { get; set; }
  public Guid MemberId { get; set; }
  public Guid MemberStoreId { get; set; }
  public int Permission { get; set; }
}
