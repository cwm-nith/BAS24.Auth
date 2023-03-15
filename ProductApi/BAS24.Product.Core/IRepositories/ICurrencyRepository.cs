using BAS24.Libs.CQRS.Queries;
using BAS24.Product.Core.Entities.Currency;

namespace BAS24.Product.Core.IRepositories;

public interface ICurrencyRepository
{
  Task AddAsync(CurrencyEntity c);
  Task UpdateAsync(CurrencyEntity c);
  Task<PagedResult<CurrencyEntity>> GetAllByStoreOwnerAsync(Guid storeOwnerId, PagedQuery pagedQuery);
  Task<PagedResult<CurrencyEntity>> GetAllActiveByStoreOwnerAsync(Guid storeOwnerId, PagedQuery pagedQuery);
  Task<PagedResult<CurrencyEntity>> GetAllAsync(PagedQuery pagedQuery);
  Task<CurrencyEntity?> GetByIdAsync(Guid id);
  Task<CurrencyEntity?> GetBaseCurrencyAsync(Guid storeOwnerId);
  Task<CurrencyEntity?> GetLocalCurrencyAsync(Guid storeOwnerId);
  Task DeleteAsync(Guid id);
}
