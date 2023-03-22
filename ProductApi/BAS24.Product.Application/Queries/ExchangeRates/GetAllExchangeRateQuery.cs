using BAS24.Libs.CQRS.Queries;
using BAS24.Product.Core.Dtos.ExchangeRate;

namespace BAS24.Product.Application.Queries.ExchangeRates;

public class GetAllExchangeRateQuery:PagedQuery,IQuery<PagedResult<ExchangeRateDto>>
{
  
}
