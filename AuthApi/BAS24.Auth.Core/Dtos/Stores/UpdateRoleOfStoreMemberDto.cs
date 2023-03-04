namespace BAS24.Api.Dtos.Stores;

public class UpdateRoleOfStoreMemberDto
{
  public Guid StoreId { get; set; }
  public Guid MemberStoreId { get; set; }
  public int Permission { get; set; }
}
