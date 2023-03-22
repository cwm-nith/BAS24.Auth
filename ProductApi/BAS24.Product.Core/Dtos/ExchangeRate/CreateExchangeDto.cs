namespace BAS24.Product.Core.Dtos.ExchangeRate;

public class CreateExchangeDto
{
  public Guid CurrencyId { get; set; }
  public decimal Rate { get; set; }
  public decimal SetRate { get; set; }
  public decimal LocalSetRate { get; set; }
  public decimal BaseSetRate { get; set; }
}
