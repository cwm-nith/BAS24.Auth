using BAS24.Libs.CQRS.Commands;

namespace BAS24.Product.Application.Commands.Currency;

public class DeleteCurrencyCommand:ICommand
{
  public Guid Id { get; set; }
  public Guid OwnerId { get; set; }
}
