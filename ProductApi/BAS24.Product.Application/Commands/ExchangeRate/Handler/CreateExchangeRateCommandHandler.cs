using BAS24.Libs.CQRS.Commands;

namespace BAS24.Product.Application.Commands.ExchangeRate.Handler;

public class CreateExchangeRateCommandHandler:ICommandHandler<CreateExchangeRateCommand>
{
  public Task HandleAsync(CreateExchangeRateCommand command)
  {
    throw new NotImplementedException();
  }
}
