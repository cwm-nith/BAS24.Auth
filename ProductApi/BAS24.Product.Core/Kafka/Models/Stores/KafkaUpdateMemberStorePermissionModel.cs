namespace BAS24.Product.Core.Kafka.Models.Stores;

public class KafkaUpdateMemberStorePermissionModel:IBaseKafkaModel
{
  public Guid StoreId { get; set; }
  public Guid MemberId { get; set; }
  public Guid MemberStoreId { get; set; }
  public int Permission { get; set; }
}
