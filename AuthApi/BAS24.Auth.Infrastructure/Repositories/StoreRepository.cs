using BAS24.Api.Dtos.Stores;
using BAS24.Api.Entities.Stores;
using BAS24.Api.IRepositories;
using BAS24.Auth.Infrastructure.Postgres;
using BAS24.Auth.Infrastructure.Postgres.Store;
using BAS24.Libs.CQRS.Queries;
using BAS24.Libs.Postgres;
using Microsoft.EntityFrameworkCore;

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

  public Task ActivateStoreAsync(Guid ownerId, Guid storeId)
  {
    throw new NotImplementedException();
  }

  public Task DeactivateStoreAsync(Guid ownerId, Guid storeId)
  {
    throw new NotImplementedException();
  }

  public Task DeleteStoreAsync(Guid ownerId, Guid storeId)
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

  public async Task<StoreEntity?> GetStoreByOwnerAsync(Guid ownerId, Guid storeId)
  {
    // var store = await _repository.FirstOrDefaultAsync(i => i.Id == storeId && i.OwnerId == ownerId);
    // return store?.AsEntity();
    var store = await _repository.Context.Stores?.Include(i => i.Owner)
      .FirstOrDefaultAsync(i => i.Id == storeId && i.OwnerId == ownerId)!;
    return store?.AsEntity();
  }

  public Task<PagedResult<StoreEntity>> GetStoresByUserAsync(Guid ownerId)
  {
    throw new NotImplementedException();
  }

  public async Task<PagedResult<StoreEntity>> GetAllStoresAsync(GetStoresPageDto dto)
  {
    var q = await _repository.Context
      .Stores?.AsQueryable()
      .PaginateAsync(dto.Page, dto.Results)!;
    var result = q.Map(i => i.AsEntity());
    return result;
  }

  public async Task<StoreEntity?> GetStoreByIdAsync(Guid id)
  {
    var store = await _repository.FirstOrDefaultAsync(i => i.Id == id);
    return store?.AsEntity();
  }
}
