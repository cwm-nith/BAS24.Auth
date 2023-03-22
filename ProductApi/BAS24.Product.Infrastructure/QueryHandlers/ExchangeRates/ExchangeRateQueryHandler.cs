using BAS24.Libs.CQRS.Queries;
using BAS24.Product.Application.Queries.ExchangeRates;
using BAS24.Product.Core.Dtos.ExchangeRate;
using BAS24.Product.Core.IRepositories;
using BAS24.Product.Infrastructure.Postgres.ExchangeRate;

namespace BAS24.Product.Infrastructure.QueryHandlers.ExchangeRates;

public class ExchangeRateQueryHandler:IQueryHandler<GetAllExchangeRateQuery, PagedResult<ExchangeRateDto>>
{
  private readonly IExchangeRepository _repository;

  public ExchangeRateQueryHandler(IExchangeRepository repository)
  {
    _repository = repository;
  }

  public async Task<PagedResult<ExchangeRateDto>> HandleAsync(GetAllExchangeRateQuery query)
  {
    var data = await _repository.GetAllAsync(query);
    return data.Map(i => i.AsDto());
  }
}
