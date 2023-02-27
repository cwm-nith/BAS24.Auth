using BAS24.Api.Entities.Stores;
using BAS24.Api.IRepositories;
using BAS24.Auth.Infrastructure.Postgres;
using BAS24.Auth.Infrastructure.Postgres.Store;
using BAS24.Libs.CQRS.Queries;

namespace BAS24.Auth.Infrastructure.Repositories;

public class StoreRepository:IStoreRepository
{
  private readonly IPostgresRepository<StoreTable> _repository;

  public StoreRepository(IPostgresRepository<StoreTable> repository)
  {
    _repository = repository;
  }

  public Task CreateStoreAsync(StoreEntity entity)
  {
    return _repository.AddAsync(entity.AsTable());
  }

  public Task UpdateStoreAsync(StoreEntity entity)
  {
    return _repository.UpdateAsync(entity.AsTable());
  }

  public Task ActivateStoreAsync(string ownerId, string storeId)
  {
    throw new NotImplementedException();
  }

  public Task DeactivateStoreAsync(string ownerId, string storeId)
  {
    throw new NotImplementedException();
  }

  public Task DeleteStoreAsync(string ownerId, string storeId)
  {
    throw new NotImplementedException();
  }

  public Task AddUserToStoreAsync()
  {
    throw new NotImplementedException();
  }

  public Task UpdateUserStoreRoleAsync()
  {
    throw new NotImplementedException();
  }

  public Task RemoveUserFromStoreAsync()
  {
    throw new NotImplementedException();
  }

  public Task<StoreEntity?> GetStoreAsync(string ownerId, string storeId)
  {
    throw new NotImplementedException();
  }

  public Task<PagedResult<StoreEntity>> GetStoresByUserAsync(string ownerId)
  {
    throw new NotImplementedException();
  }

  public Task<PagedResult<StoreEntity>> GetAllStoresAsync()
  {
    throw new NotImplementedException();
  }
}
