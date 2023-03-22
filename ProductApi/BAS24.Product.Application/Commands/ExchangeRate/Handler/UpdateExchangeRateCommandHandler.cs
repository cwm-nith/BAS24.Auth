using BAS24.Libs.CQRS.Commands;
using BAS24.Product.Core.Exceptions.ExchangeRates;
using BAS24.Product.Core.IRepositories;

namespace BAS24.Product.Application.Commands.ExchangeRate.Handler;

public class UpdateExchangeRateCommandHandler:ICommandHandler<UpdateExchangeRateCommand>
{
  private readonly IExchangeRepository _exchangeRepository;

  public UpdateExchangeRateCommandHandler(IExchangeRepository exchangeRepository)
  {
    _exchangeRepository = exchangeRepository;
  }

  public async Task HandleAsync(UpdateExchangeRateCommand command)
  {
    var data = await _exchangeRepository.GetByIdAsync(command.Id);
    if (data is null) throw new ExchangeRateNotFoundException();
    data.SetRate = command.SetRate;
    data.Rate = command.Rate;
    data.UpdatedAt = DateTime.UtcNow;
    data.BaseSetRate = command.BaseSetRate;
    data.LocalSetRate = command.LocalSetRate;
    await _exchangeRepository.UpdateAsync(data);
  }
}
