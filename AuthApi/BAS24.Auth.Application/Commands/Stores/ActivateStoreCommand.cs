using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores;

public class ActivateStoreCommand:ICommand
{
  public Guid OwnerId { get; set; }

  public ActivateStoreCommand(Guid ownerId)
  {
    OwnerId = ownerId;
  }
}
