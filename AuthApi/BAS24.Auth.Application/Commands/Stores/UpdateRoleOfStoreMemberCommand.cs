using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores;

public class UpdateRoleOfStoreMemberCommand:ICommand
{
  public Guid StoreId { get; set; }
  public Guid StoreMemberId { get; set; }
  public int Permission { get; set; }
}
