using BAS24.Libs.CQRS.Queries;
using BAS24.Libs.Postgres;
using BAS24.Product.Core.Entities.ExchangeRate;
using BAS24.Product.Core.IRepositories;
using BAS24.Product.Infrastructure.Postgres;
using BAS24.Product.Infrastructure.Postgres.ExchangeRate;

namespace BAS24.Product.Infrastructure.Repositories;

public class ExchangeRepository:IExchangeRepository
{
  private readonly IPostgresRepository<ExchangeRateTable> _repository;

  public ExchangeRepository(IPostgresRepository<ExchangeRateTable> repository)
  {
    _repository = repository;
  }

  public Task CreateAsync(ExchangeRateEntity e) => _repository.AddAsync(e.AsTable());

  public Task UpdateAsync(ExchangeRateEntity e) => _repository.UpdateAsync(e.AsTable());

  public Task DeleteAsync(Guid id) => _repository.DeleteAsync(id);

  public async Task<ExchangeRateEntity?> GetByIdAsync(Guid id)
  {
    var data = await _repository.FirstOrDefaultAsync(i => i.Id == id);
    return data?.AsEntity();
  }

  public async Task<PagedResult<ExchangeRateEntity>> GetAllAsync(PagedQuery page)
  {
    var data = await _repository.Context.ExchangeRates?.PaginateAsync(page)!;
    return data.Map(i => i.AsEntity());
  }
}
