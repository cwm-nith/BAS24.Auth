using BAS24.Libs.CQRS.Queries;
using BAS24.Product.Core.Dtos.Currency;

namespace BAS24.Product.Application.Queries.Currency;

public class GetAllActiveByStoreQuery:PagedQuery,IQuery<PagedResult<CurrencyDto>>
{
  public Guid StoreId { get; set; }
}
