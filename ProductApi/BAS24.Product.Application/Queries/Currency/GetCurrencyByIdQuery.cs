using BAS24.Libs.CQRS.Queries;
using BAS24.Product.Core.Dtos.Currency;

namespace BAS24.Product.Application.Queries.Currency;

public class GetCurrencyByIdQuery : IQuery<CurrencyDto>
{
  public Guid Id { get; set; }
}
