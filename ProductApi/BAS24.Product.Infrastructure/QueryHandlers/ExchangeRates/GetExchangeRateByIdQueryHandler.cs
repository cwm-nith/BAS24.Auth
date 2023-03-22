using BAS24.Libs.CQRS.Queries;
using BAS24.Product.Application.Queries.ExchangeRates;
using BAS24.Product.Core.Dtos.ExchangeRate;
using BAS24.Product.Core.Exceptions.ExchangeRates;
using BAS24.Product.Core.IRepositories;
using BAS24.Product.Infrastructure.Postgres.ExchangeRate;

namespace BAS24.Product.Infrastructure.QueryHandlers.ExchangeRates;

public class GetExchangeRateByIdQueryHandler:IQueryHandler<GetExchangeRateByIdQuery, ExchangeRateDto>
{
  private readonly IExchangeRepository _repository;

  public GetExchangeRateByIdQueryHandler(IExchangeRepository repository)
  {
    _repository = repository;
  }

  public async Task<ExchangeRateDto>? HandleAsync(GetExchangeRateByIdQuery query)
  {
    var data = await _repository.GetByIdAsync(query.Id);
    if (data is null) throw new ExchangeRateNotFoundException();
    return data.AsDto();
  }
}
