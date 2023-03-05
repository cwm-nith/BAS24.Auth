namespace BAS24.Api.Dtos.Stores;

public class RemoveStoreMemberDto
{
  public Guid StoreId { get; set; }
  public Guid StoreMemberId { get; set; }
  public Guid MemberId { get; set; }
}
