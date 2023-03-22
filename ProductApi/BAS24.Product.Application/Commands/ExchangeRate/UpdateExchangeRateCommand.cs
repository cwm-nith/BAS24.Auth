using BAS24.Libs.CQRS.Commands;

namespace BAS24.Product.Application.Commands.ExchangeRate;

public class UpdateExchangeRateCommand:ICommand
{
  public Guid Id { get; set; }
  public decimal Rate { get; set; }
  public decimal SetRate { get; set; }
  public decimal LocalSetRate { get; set; }
  public decimal BaseSetRate { get; set; }
}
