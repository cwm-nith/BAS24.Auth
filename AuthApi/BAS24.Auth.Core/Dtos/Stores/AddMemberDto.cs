namespace BAS24.Api.Dtos.Stores;

public class AddMemberDto
{
  public Guid StoreId { get; set; }
  public Guid MemberId { get; set; }
  public int Permission { get; set; }
}
