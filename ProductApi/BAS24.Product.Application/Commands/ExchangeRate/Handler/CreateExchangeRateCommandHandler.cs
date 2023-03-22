using BAS24.Libs.CQRS.Commands;
using BAS24.Product.Core.Entities.ExchangeRate;
using BAS24.Product.Core.IRepositories;

namespace BAS24.Product.Application.Commands.ExchangeRate.Handler;

public class CreateExchangeRateCommandHandler:ICommandHandler<CreateExchangeRateCommand>
{
  private readonly IExchangeRepository _exchangeRepository;

  public CreateExchangeRateCommandHandler(IExchangeRepository exchangeRepository)
  {
    _exchangeRepository = exchangeRepository;
  }

  public async Task HandleAsync(CreateExchangeRateCommand command)
  {
    var entity = new ExchangeRateEntity(
      id: command.Id, 
      currencyId: command.CurrencyId, 
      rate: command.Rate, 
      setRate: command.SetRate, 
      localSetRate: command.LocalSetRate, 
      baseSetRate: command.BaseSetRate, 
      createdAt: DateTime.UtcNow, 
      updatedAt: DateTime.UtcNow
      );
    await _exchangeRepository.CreateAsync(entity);
  }
}
