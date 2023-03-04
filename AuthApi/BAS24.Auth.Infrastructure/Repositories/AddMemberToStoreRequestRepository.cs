using BAS24.Api.Entities.Stores;
using BAS24.Api.IRepositories;
using BAS24.Auth.Infrastructure.Postgres;
using BAS24.Auth.Infrastructure.Postgres.Store;

namespace BAS24.Auth.Infrastructure.Repositories;

public class AddMemberToStoreRequestRepository : IAddMemberToStoreRequestRepository
{
  private readonly IPostgresRepository<AddMemberToStoreRequestTable> _repository;

  public AddMemberToStoreRequestRepository(IPostgresRepository<AddMemberToStoreRequestTable> repository)
  {
    _repository = repository;
  }

  public Task CreateAsync(AddMemberToStoreRequestEntity e)
  {
    return _repository.AddAsync(e.AsTable());
  }

  public Task UpdateAsync(AddMemberToStoreRequestEntity e)
  {
    return _repository.UpdateAsync(e.AsTable());
  }

  public Task DeleteAsync(Guid id)
  {
    return _repository.DeleteAsync(id);
  }

  public async Task<AddMemberToStoreRequestEntity?> GetById(Guid id)
  {
    var data = await _repository.FirstOrDefaultAsync(i => i.Id == id);
    return data?.AsEntity();
  }
}
