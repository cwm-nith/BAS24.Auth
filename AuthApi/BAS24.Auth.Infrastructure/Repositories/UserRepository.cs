using BAS24.Api.Entities.User;
using BAS24.Api.Exceptions.Users;
using BAS24.Api.IRepositories;
using BAS24.Libs.CQRS.Queries;
using BAS24.Libs.Postgres;
using Infra.Postgres;
using Infra.Postgres.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class UserRepository : IUserRepository
{
  private readonly IPasswordHasher<UserEntity> _passwordHasher;
  private readonly IPostgresRepository<UserTable> _repository;

  public UserRepository(IPostgresRepository<UserTable> repository, IPasswordHasher<UserEntity> passwordHasher)
  {
    _repository = repository;
    _passwordHasher = passwordHasher;
  }

  public Task CreateUser(UserEntity user)
  {
    return _repository.AddAsync(user.AsTable());
  }

  public Task UpdateUser(UserEntity user)
  {
    return _repository.UpdateAsync(user.AsTable());
  }

  public async Task<UserEntity> GetByUserNameAndPassword(string userName, string password)
  {
    var table = await _repository.FirstOrDefaultAsync(x => x.Username == userName && (x.Active ?? false));
    if (table is null)
    {
      throw new UserNotFoundException();
    }

    var entity = table.AsEntity();
    var valid = entity.ValidatePassword(password, _passwordHasher);

    if (!valid)
    {
      throw new InvalidPasswordException();
    }

    return entity;
  }

  public async Task<UserEntity?> GetUserById(Guid userId)
  {
    var user = await _repository.FirstOrDefaultAsync(x => x.Id == userId);
    return user?.AsEntity();
  }

  public async Task<IEnumerable<UserEntity>?> GetUserByIds(Guid[] userIds)
  {
    var context = _repository.Context;
    var lst = await (from user in context.Users
      where userIds.Contains(user.Id)
      select user).AsNoTracking().ToListAsync();
    return lst.Select(x => x.AsEntity());
  }

  public async Task<UserEntity?> GetActiveUserByUsername(string username)
  {
    var user = await _repository.FirstOrDefaultAsync(x =>
      x.Username == username && (x.Active ?? false));
    return user?.AsEntity();
  }

  public async Task<UserEntity?> GetActiveUserByPhoneNumber(string phoneNumber)
  {
    var user = await _repository.FirstOrDefaultAsync(x =>
      x.Phones != null && x.Phones.Length > 0 && x.Phones.Contains(phoneNumber) && (x.Active ?? false));
    return user?.AsEntity();
  }

  public async Task<PagedResult<UserEntity>> GetUserPaginate(PagedQuery query)
  {
    var context = _repository.Context;
    var q = await (from user in context.Users
      where user.Active ?? false
      select user).AsNoTracking().PaginateAsync(query.Page, query.Results);
    var result = q.Map(x => x.AsEntity());
    return result;
  }

  public async Task RemoveUserById(Guid userId)
  {
    var user = await _repository.FirstOrDefaultAsync(userId);
    if (user == null)
    {
      throw new UserNotFoundException(userId.ToString());
    }

    user.Active = false;
    await _repository.UpdateAsync(user);
  }

  public async Task<int> CountAllUser()
  {
    return await _repository.CountAsync(i => true);
  }
}
