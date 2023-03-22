using BAS24.Product.Core.Dtos.Currency;

namespace BAS24.Product.Core.Dtos.ExchangeRate;

public class ExchangeRateDto
{
  public Guid Id { get; set; }
  public Guid CurrencyId { get; set; }
  public decimal Rate { get; set; }
  public decimal SetRate { get; set; }
  public decimal LocalSetRate { get; set; }
  public decimal BaseSetRate { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public CurrencyDto? Currency { get; set; }

  public ExchangeRateDto(Guid id,
    Guid currencyId,
    decimal rate,
    decimal setRate,
    decimal localSetRate,
    decimal baseSetRate,
    DateTime createdAt,
    DateTime updatedAt)
  {
    Id = id;
    CurrencyId = currencyId;
    Rate = rate;
    SetRate = setRate;
    LocalSetRate = localSetRate;
    BaseSetRate = baseSetRate;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
  }
}
