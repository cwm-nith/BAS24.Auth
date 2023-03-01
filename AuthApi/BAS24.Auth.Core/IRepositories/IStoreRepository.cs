using BAS24.Api.Dtos.Stores;
using BAS24.Api.Entities.Stores;
using BAS24.Libs.CQRS.Queries;

namespace BAS24.Api.IRepositories;

public interface IStoreRepository
{
  Task CreateStoreAsync(StoreEntity entity);
  Task UpdateStoreAsync(StoreEntity entity);
  Task ActivateStoreAsync(Guid ownerId, Guid storeId);
  Task DeactivateStoreAsync(Guid ownerId, Guid storeId);
  Task DeleteStoreAsync(Guid ownerId, Guid storeId);
  Task AddUserToStoreAsync();
  Task UpdateUserStoreRoleAsync();
  Task RemoveUserFromStoreAsync();
  Task<StoreEntity?> GetStoreByOwnerAsync(Guid ownerId, Guid storeId);
  Task<PagedResult<StoreEntity>> GetStoresByUserAsync(Guid ownerId);
  Task <PagedResult<StoreEntity>> GetAllStoresAsync(GetStoresPageDto dto);
  Task<StoreEntity?> GetStoreByIdAsync(Guid id);
}
