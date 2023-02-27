using BAS24.Api.Entities.Stores;
using BAS24.Libs.CQRS.Queries;

namespace BAS24.Api.IRepositories;

public interface IStoreRepository
{
  Task CreateStoreAsync(StoreEntity entity);
  Task UpdateStoreAsync(StoreEntity entity);
  Task ActivateStoreAsync(string ownerId, string storeId);
  Task DeactivateStoreAsync(string ownerId, string storeId);
  Task DeleteStoreAsync(string ownerId, string storeId);
  Task AddUserToStoreAsync();
  Task UpdateUserStoreRoleAsync();
  Task RemoveUserFromStoreAsync();
  Task<StoreEntity?> GetStoreAsync(string ownerId, string storeId);
  Task<PagedResult<StoreEntity>> GetStoresByUserAsync(string ownerId);
  Task <PagedResult<StoreEntity>> GetAllStoresAsync();
}
