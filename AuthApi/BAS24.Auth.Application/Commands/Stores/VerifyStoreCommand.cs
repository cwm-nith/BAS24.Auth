using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores;

public class VerifyStoreCommand:ICommand
{
  public string Code { get; set; }
  public Guid OwnerId { get; set; }

  public VerifyStoreCommand(string code, Guid ownerId)
  {
    Code = code;
    OwnerId = ownerId;
  }
}
