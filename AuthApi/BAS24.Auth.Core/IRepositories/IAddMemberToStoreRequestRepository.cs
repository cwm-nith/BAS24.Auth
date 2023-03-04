using BAS24.Api.Entities.Stores;

namespace BAS24.Api.IRepositories;

public interface IAddMemberToStoreRequestRepository
{
  Task CreateAsync(AddMemberToStoreRequestEntity e);
  Task UpdateAsync(AddMemberToStoreRequestEntity e);
  Task DeleteAsync(Guid id);
  Task<AddMemberToStoreRequestEntity?> GetById(Guid id);
}
