using BAS24.Libs.CQRS.Commands;

namespace BAS24.Product.Application.Commands.Currency.Handlers;

public class AddCurrencyCommandHandler:ICommandHandler<AddCurrencyCommand>
{
  public Task HandleAsync(AddCurrencyCommand command)
  {
    throw new NotImplementedException();
  }
}
