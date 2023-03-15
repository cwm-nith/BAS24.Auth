using BAS24.Libs.CQRS.Commands;

namespace BAS24.Product.Application.Commands.Currency;

public class AddCurrencyCommand : ICommand
{
  public Guid Id { get; set; }
  public Guid StoreOwnerId { get; set; }
  public string Symbol { get; set; }

  public string Description { get; set; }

  public bool Active { get; set; }

  public bool BaseCurrency { get; set; }

  public bool LocalCurrency { get; set; }

  public AddCurrencyCommand(
    Guid id,
    Guid storeOwnerId,
    string symbol,
    string description,
    bool active,
    bool baseCurrency,
    bool localCurrency)
  {
    Id = id;
    StoreOwnerId = storeOwnerId;
    Symbol = symbol;
    Description = description;
    Active = active;
    BaseCurrency = baseCurrency;
    LocalCurrency = localCurrency;
  }
}
