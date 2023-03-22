using BAS24.Libs.CQRS.Queries;
using BAS24.Product.Application.Queries.Currency;
using BAS24.Product.Core.Dtos.Currency;

namespace BAS24.Product.Infrastructure.QueryHandlers.Currency;

public class GetLocalCurrencyQueryHandler:IQueryHandler<GetLocalCurrencyQuery, CurrencyDto>
{
  public Task<CurrencyDto>? HandleAsync(GetLocalCurrencyQuery query)
  {
    throw new NotImplementedException();
  }
}
