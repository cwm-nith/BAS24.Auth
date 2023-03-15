namespace BAS24.Product.Core.Dtos.Currency;

public class CurrencyDto
{
  public Guid Id { get; set; }
  public Guid StoreOwnerId { get; set; }
  public string Symbol { get; set; }

  public string Description { get; set; }

  public bool Active { get; set; }

  public bool BaseCurrency { get; set; }

  public bool LocalCurrency { get; set; }

  public DateTime CreatedAt { get; set; }

  public DateTime UpdatedAt { get; set; }

  public CurrencyDto(Guid id,
    Guid storeOwnerId,
    string symbol,
    string description,
    bool active,
    bool baseCurrency,
    bool localCurrency,
    DateTime createdAt,
    DateTime updatedAt)
  {
    Id = id;
    StoreOwnerId = storeOwnerId;
    Symbol = symbol;
    Description = description;
    Active = active;
    BaseCurrency = baseCurrency;
    LocalCurrency = localCurrency;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
  }
}
