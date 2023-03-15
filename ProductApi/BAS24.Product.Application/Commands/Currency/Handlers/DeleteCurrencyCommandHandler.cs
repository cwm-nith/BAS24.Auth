using BAS24.Libs.CQRS.Commands;

namespace BAS24.Product.Application.Commands.Currency.Handlers;

public class DeleteCurrencyCommandHandler:ICommandHandler<DeleteCurrencyCommand>
{
  public Task HandleAsync(DeleteCurrencyCommand command)
  {
    throw new NotImplementedException();
  }
}
