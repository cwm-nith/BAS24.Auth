using BAS24.Api.Commons;
using BAS24.Api.Entities.User;
using BAS24.Libs.CQRS.Queries;

namespace BAS24.Api.IRepositories;

public interface IUserRepository
{
  Task CreateUser(UserEntity user);
  Task UpdateUserAsync(UserEntity user);
  Task<UserEntity> GetByUserNameAndPassword(string userName, string password, UserFilterOptions? userFilterOptions = null);
  Task<UserEntity?> GetUserById(Guid userId, UserFilterOptions? userFilterOptions = null);
  Task<IEnumerable<UserEntity>?> GetUserByIds(Guid[] userIds, UserFilterOptions? userFilterOptions = null);
  Task<UserEntity?> GetUserByUsername(string username, UserFilterOptions? userFilterOptions = null);
  Task<UserEntity?> GetUserByPhoneNumberAsync(string phoneNumber, UserFilterOptions? userFilterOptions = null);
  Task<UserEntity?> GetUserByEmailAsync(string email, UserFilterOptions? userFilterOptions = null);
  Task<PagedResult<UserEntity>> GetUserPaginate(PagedQuery query, UserFilterOptions? userFilterOptions = null);
  Task RemoveUserById(Guid userId, UserFilterOptions? userFilterOptions = null);
  Task<int> CountAllUser(UserFilterOptions? userFilterOptions = null);
  Task VerifyCodeAsync(string code, string to);
}
