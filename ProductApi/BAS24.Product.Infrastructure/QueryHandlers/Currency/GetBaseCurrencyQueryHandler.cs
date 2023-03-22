using BAS24.Libs.CQRS.Queries;
using BAS24.Product.Application.Queries.Currency;
using BAS24.Product.Core.Dtos.Currency;

namespace BAS24.Product.Infrastructure.QueryHandlers.Currency;

public class GetBaseCurrencyQueryHandler:IQueryHandler<GetBaseCurrencyQuery, CurrencyDto>
{
  public Task<CurrencyDto>? HandleAsync(GetBaseCurrencyQuery query)
  {
    throw new NotImplementedException();
  }
}
