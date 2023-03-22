using BAS24.Libs.CQRS.Queries;
using BAS24.Product.Application.Queries.Currency;
using BAS24.Product.Core.Dtos.Currency;

namespace BAS24.Product.Infrastructure.QueryHandlers.Currency;

public class GetCurrencyByIdQueryHandler:IQueryHandler<GetCurrencyByIdQuery, CurrencyDto>
{
  public Task<CurrencyDto>? HandleAsync(GetCurrencyByIdQuery query)
  {
    throw new NotImplementedException();
  }
}
