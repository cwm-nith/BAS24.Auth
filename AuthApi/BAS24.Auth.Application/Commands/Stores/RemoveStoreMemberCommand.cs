using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores;

public class RemoveStoreMemberCommand:ICommand
{
  public Guid StoreId { get; set; }
  public Guid StoreMemberId { get; set; }
  public Guid MemberId { get; set; }
}
