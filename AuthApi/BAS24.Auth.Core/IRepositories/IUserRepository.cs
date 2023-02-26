using BAS24.Api.Entities.User;
using BAS24.Libs.CQRS.Queries;

namespace BAS24.Api.IRepositories;

public interface IUserRepository
{
  Task CreateUser(UserEntity user);
  Task UpdateUser(UserEntity user);
  Task<UserEntity> GetByUserNameAndPassword(string userName, string password);
  Task<UserEntity?> GetUserById(Guid userId);
  Task<IEnumerable<UserEntity>?> GetUserByIds(Guid[] userIds);
  Task<UserEntity?> GetActiveUserByUsername(string username);
  Task<UserEntity?> GetActiveUserByPhoneNumber(string phoneNumber);
  Task<PagedResult<UserEntity>> GetUserPaginate(PagedQuery query);
  Task RemoveUserById(Guid userId);
  Task<int> CountAllUser();
}
