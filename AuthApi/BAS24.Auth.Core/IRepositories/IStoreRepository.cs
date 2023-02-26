namespace BAS24.Api.IRepositories;

public interface IStoreRepository
{
  Task CreateStoreAsync();
  Task UpdateStoreAsync();
  Task ActivateStoreAsync();
  Task DeactivateStoreAsync();
  Task DeleteStoreAsync();
  Task AddUserToStoreAsync();
  Task UpdateUserStoreRoleAsync();
  Task RemoveUserFromStoreAsync();
  Task GetStoreAsync();
  Task GetStoresByUserAsync();
  Task GetAllStoresAsync();
}
