using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores;

public class DeleteStoreCommand:ICommand
{
  public Guid Id { get; set; }
  public Guid OwnerId { get; set; }
}
