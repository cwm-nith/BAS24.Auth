using BAS24.Api.Dtos.SocialLinks;
using BAS24.Api.Dtos.Stores;
using BAS24.Api.Entities.Stores;
using BAS24.Libs.CQRS.Queries;

namespace BAS24.Api.IRepositories;

public interface IStoreRepository
{
  Task CreateStoreAsync(StoreEntity entity);
  Task UpdateStoreAsync(StoreEntity entity);
  Task ActivateStoreAsync(Guid ownerId, Guid storeId);
  Task VerifyStoreAsync(Guid id, Guid ownerId, string code);
  Task DeactivateStoreAsync(Guid ownerId, Guid storeId);
  Task DeleteStoreAsync(Guid ownerId, Guid storeId);
  Task AddUserToStoreAsync(Guid id, AddMemberDto dto);
  Task UpdateUserStoreRoleAsync(Guid ownerId, UpdateRoleOfStoreMemberDto dto);
  Task RemoveUserFromStoreAsync();
  Task<StoreEntity?> GetStoreByOwnerAsync(GetStoreByOwnerDto dto);
  Task<PagedResult<StoreEntity>> GetStoresByUserAsync(Guid ownerId);
  Task <PagedResult<StoreEntity>> GetAllStoresAsync(GetStoresPageDto dto);
  Task<StoreEntity?> GetStoreByIdAsync(Guid id, bool isActive);
  List<RoleDto> GetRoles();
  Task<PagedResult<StoreMemberEntity>> GetStoreMembersAsync(GetStoreMembersDto dto);
}
