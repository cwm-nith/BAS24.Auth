using BAS24.Libs.CQRS.Queries;
using BAS24.Libs.Postgres;
using BAS24.Product.Core.Entities.Currency;
using BAS24.Product.Core.IRepositories;
using BAS24.Product.Infrastructure.Postgres;
using BAS24.Product.Infrastructure.Postgres.Currency;

namespace BAS24.Product.Infrastructure.Repositories;

public class CurrencyRepository : ICurrencyRepository
{
  private readonly IPostgresRepository<CurrencyTable> _repository;

  public CurrencyRepository(IPostgresRepository<CurrencyTable> repository)
  {
    _repository = repository;
  }

  public Task AddAsync(CurrencyEntity c)
    => _repository.AddAsync(c.AsTable());

  public Task UpdateAsync(CurrencyEntity c)
    => _repository.UpdateAsync(c.AsTable());

  public async Task<PagedResult<CurrencyEntity>> GetAllByStoreOwnerAsync(Guid storeOwnerId, PagedQuery pagedQuery)
  {
    var data = await _repository.Context
      .Currencies?.Where(i => i.StoreOwnerId == storeOwnerId)
      .PaginateAsync(pagedQuery)!;

    return data.Map(i => i.AsEntity());
  }

  public async Task<PagedResult<CurrencyEntity>> GetAllActiveByStoreOwnerAsync(Guid storeOwnerId, PagedQuery pagedQuery)
  {
    var data = await _repository.Context
      .Currencies?.Where(i => i.StoreOwnerId == storeOwnerId && i.Active)
      .PaginateAsync(pagedQuery)!;

    return data.Map(i => i.AsEntity());
  }

  public async Task<PagedResult<CurrencyEntity>> GetAllAsync(PagedQuery pagedQuery)
  {
    var data = await _repository.Context
      .Currencies?.PaginateAsync(pagedQuery)!;

    return data.Map(i => i.AsEntity());
  }

  public async Task<CurrencyEntity?> GetByIdAsync(Guid id)
  {
    var data = await _repository.FirstOrDefaultAsync(i => i.Id == id);
    return data?.AsEntity();
  }

  public async Task<CurrencyEntity?> GetBaseCurrencyAsync(Guid storeOwnerId)
  {
    var data = await _repository.FirstOrDefaultAsync(i => i.Id == storeOwnerId && i.BaseCurrency);
    return data?.AsEntity();
  }

  public async Task<CurrencyEntity?> GetLocalCurrencyAsync(Guid storeOwnerId)
  {
    var data = await _repository.FirstOrDefaultAsync(i => i.Id == storeOwnerId && i.LocalCurrency);
    return data?.AsEntity();
  }

  public Task DeleteAsync(Guid id)
    => _repository.DeleteAsync(id);
}
