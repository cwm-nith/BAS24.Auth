using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores;

public class AcceptedAddMemberRequestCommand:ICommand
{
  public Guid StoreMemberId { get; set; }
  public Guid StoreId { get; set; }
  public Guid MemberId { get; set; }
}
