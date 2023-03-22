namespace BAS24.Product.Core.Dtos.Currency;

public class UpdateCurrencyDto
{
  public string Symbol { get; set; }

  public string Description { get; set; }

  public bool Active { get; set; }

  public UpdateCurrencyDto(string symbol, string description, bool active)
  {
    Symbol = symbol;
    Description = description;
    Active = active;
  }
}
