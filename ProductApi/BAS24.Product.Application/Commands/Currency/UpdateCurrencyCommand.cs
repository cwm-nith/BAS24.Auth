using BAS24.Libs.CQRS.Commands;

namespace BAS24.Product.Application.Commands.Currency;

public class UpdateCurrencyCommand:ICommand
{
  public Guid Id { get; set; }
  public string Symbol { get; set; }

  public string Description { get; set; }

  public bool Active { get; set; }

  public UpdateCurrencyCommand(Guid id, string symbol, string description, bool active)
  {
    Id = id;
    Symbol = symbol;
    Description = description;
    Active = active;
  }
}
