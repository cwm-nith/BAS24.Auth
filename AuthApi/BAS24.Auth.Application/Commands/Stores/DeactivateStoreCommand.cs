using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores;

public class DeactivateStoreCommand:ICommand
{
  public Guid OwnerId { get; set; }

  public DeactivateStoreCommand(Guid ownerId)
  {
    OwnerId = ownerId;
  }
}
