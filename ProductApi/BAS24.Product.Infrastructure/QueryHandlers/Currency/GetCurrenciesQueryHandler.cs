using BAS24.Libs.CQRS.Queries;
using BAS24.Product.Application.Queries.Currency;
using BAS24.Product.Core.Dtos.Currency;

namespace BAS24.Product.Infrastructure.QueryHandlers.Currency;

public class GetCurrenciesQueryHandler: IQueryHandler<GetCurrenciesQuery, List<CurrencyDto>>
{
  public Task<List<CurrencyDto>> HandleAsync(GetCurrenciesQuery query)
  {
    throw new NotImplementedException();
  }
}
