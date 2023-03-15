namespace BAS24.Product.Core.Dtos.Currency;

public class AddCurrencyDto
{
  public string Symbol { get; set; }

  public string Description { get; set; }

  public bool BaseCurrency { get; set; }

  public bool LocalCurrency { get; set; }

  public AddCurrencyDto(
    string symbol,
    string description,
    bool baseCurrency,
    bool localCurrency)
  {
    Symbol = symbol;
    Description = description;
    BaseCurrency = baseCurrency;
    LocalCurrency = localCurrency;
  }
}
