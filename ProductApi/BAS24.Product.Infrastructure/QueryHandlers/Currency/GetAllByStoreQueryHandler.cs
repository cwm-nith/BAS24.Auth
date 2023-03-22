using BAS24.Libs.CQRS.Queries;
using BAS24.Product.Application.Queries.Currency;
using BAS24.Product.Core.Dtos.Currency;

namespace BAS24.Product.Infrastructure.QueryHandlers.Currency;

public class GetAllByStoreQueryHandler:IQueryHandler<GetAllByStoreQuery, PagedResult<CurrencyDto>>
{
  public Task<PagedResult<CurrencyDto>>? HandleAsync(GetAllByStoreQuery query)
  {
    throw new NotImplementedException();
  }
}
