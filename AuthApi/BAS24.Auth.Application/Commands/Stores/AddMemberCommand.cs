using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores;

public class AddMemberCommand:ICommand
{
  public Guid StoreId { get; set; }
  public Guid MemberId { get; set; }
  public int Permission { get; set; }
}
