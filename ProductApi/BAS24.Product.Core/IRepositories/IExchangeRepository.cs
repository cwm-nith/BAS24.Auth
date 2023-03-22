using BAS24.Libs.CQRS.Queries;
using BAS24.Product.Core.Entities.ExchangeRate;

namespace BAS24.Product.Core.IRepositories;

public interface IExchangeRepository
{
  Task CreateAsync(ExchangeRateEntity e);
  Task UpdateAsync(ExchangeRateEntity e);
  Task DeleteAsync(Guid id);
  Task<ExchangeRateEntity?> GetByIdAsync(Guid id);
  Task<PagedResult<ExchangeRateEntity>> GetAllAsync(PagedQuery page);
}
