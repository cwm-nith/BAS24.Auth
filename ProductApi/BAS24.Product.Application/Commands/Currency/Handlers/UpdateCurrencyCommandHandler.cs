using BAS24.Libs.CQRS.Commands;

namespace BAS24.Product.Application.Commands.Currency.Handlers;

public class UpdateCurrencyCommandHandler:ICommandHandler<UpdateCurrencyCommand, Guid>
{
  public Task HandleAsync(UpdateCurrencyCommand command, Guid id)
  {
    throw new NotImplementedException();
  }
}
