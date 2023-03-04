using BAS24.Api.Commons;
using BAS24.Api.Entities.User;
using BAS24.Api.Exceptions.Users;
using BAS24.Api.IRepositories;
using BAS24.Auth.Infrastructure.Postgres;
using BAS24.Auth.Infrastructure.Postgres.User;
using BAS24.Libs.CQRS.Queries;
using BAS24.Libs.Postgres;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BAS24.Auth.Infrastructure.Repositories;

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

  public async Task<UserEntity> GetByUserNameAndPassword(string userName, string password, UserFilterOptions? options)
  {
    UserTable? user;
    if (options is null)
    {
      user = await _repository
        .FirstOrDefaultAsync(x =>
          x.Username == userName && (x.Active ?? false));
    }
    else
    {
      user = await _repository
        .FirstOrDefaultAsync(x =>
          x.Username == userName && x.Active == options.Active && x.IsApprove == options.IsApprove &&
          x.IsLock == options.IsLock);
    }

    if (user is null)
    {
      throw new UserNotFoundException();
    }

    var entity = user.AsEntity();
    var valid = entity.ValidatePassword(password, _passwordHasher);

    if (!valid)
    {
      throw new InvalidPasswordException();
    }

    return entity;
  }

  public async Task<UserEntity?> GetUserById(Guid userId, UserFilterOptions? options)
  {
    UserTable? user;
    if (options is null)
    {
      user = await _repository
        .FirstOrDefaultAsync(x =>
          x.Id == userId && (x.Active ?? false));
    }
    else
    {
      user = await _repository
        .FirstOrDefaultAsync(x =>
          x.Id == userId && x.IsApprove == options.IsApprove && x.IsLock == options.IsLock &&
          x.Active == options.Active);
    }

    return user?.AsEntity();
  }

  public async Task<IEnumerable<UserEntity>?> GetUserByIds(Guid[] userIds, UserFilterOptions? options)
  {
    var context = _repository.Context;
    List<UserTable> lst;
    if (options is null)
    {
      lst = await (from user in context.Users
        where userIds.Contains(user.Id) && (user.Active ?? false)
        select user).AsNoTracking().ToListAsync();
    }
    else
    {
      lst = await (from user in context.Users
        where userIds.Contains(user.Id) && user.Active == options.Active && user.IsLock == options.IsLock &&
              user.IsApprove == options.IsApprove
        select user).AsNoTracking().ToListAsync();
    }

    return lst.Select(x => x.AsEntity());
  }

  public async Task<UserEntity?> GetUserByUsername(string username, UserFilterOptions? options)
  {
    UserTable? user;
    if (options is null)
    {
      user = await _repository.FirstOrDefaultAsync(x =>
        x.Username == username && (x.Active ?? false));
    }
    else
    {
      user = await _repository.FirstOrDefaultAsync(x =>
        x.Username == username && (x.Active ?? false) == options.Active && x.IsApprove == options.IsApprove &&
        x.IsLock == options.IsLock);
    }

    return user?.AsEntity();
  }

  public async Task<UserEntity?> GetUserByPhoneNumber(string phoneNumber, UserFilterOptions? options)
  {
    UserTable? user;
    if (options is null)
    {
      user = await _repository
        .FirstOrDefaultAsync(x =>
          x.Phone == phoneNumber && (x.Active ?? false));
    }
    else
    {
      user = await _repository
        .FirstOrDefaultAsync(x =>
          x.Phone == phoneNumber && (x.Active ?? false) == options.Active && x.IsApprove == options.IsApprove &&
          x.IsLock == options.IsLock);
    }

    return user?.AsEntity();
  }

  public async Task<UserEntity?> GetUserByEmailAsync(string email, UserFilterOptions? options)
  {
    UserTable? user;
    if (options is null)
    {
      user = await _repository
        .FirstOrDefaultAsync(x =>
          x.Email == email && (x.Active ?? false));
    }
    else
    {
      user = await _repository
        .FirstOrDefaultAsync(x =>
          x.Email == email && (x.Active ?? false) && x.IsApprove == options.IsApprove && x.IsLock == options.IsLock);
    }

    return user?.AsEntity();
  }

  public async Task<PagedResult<UserEntity>> GetUserPaginate(PagedQuery query, UserFilterOptions? options)
  {
    var context = _repository.Context;
    PagedResult<UserTable> q;
    if (options is null)
    {
      q = await (from user in context.Users
        where user.Active ?? false
        select user).AsNoTracking().PaginateAsync(query.Page, query.Results);
    }
    else
    {
      q = await (from user in context.Users
        where (user.Active ?? false) == options.Active && user.IsApprove == options.IsApprove &&
              user.IsLock == options.IsLock
        select user).AsNoTracking().PaginateAsync(query.Page, query.Results);
    }

    var result = q.Map(x => x.AsEntity());
    return result;
  }

  public async Task RemoveUserById(Guid userId, UserFilterOptions? options)
  {
    UserTable? user;
    if (options is null)
    {
      user = await _repository
        .FirstOrDefaultAsync(i =>
          i.Id == userId && (i.Active ?? false));
    }
    else
    {
      user = await _repository
        .FirstOrDefaultAsync(i =>
          i.Id == userId && i.IsApprove == options.IsApprove && i.Active == options.Active && i.IsLock == options.IsLock);
    }
    if (user == null)
    {
      throw new UserNotFoundException(userId.ToString());
    }

    user.Active = false;
    await _repository.UpdateAsync(user);
  }

  public async Task<int> CountAllUser(UserFilterOptions? options)
  {
    if (options is null)
    {
      return await _repository.CountAsync(i => i.Active ?? false);
    }

    return await _repository.CountAsync(i =>
      i.IsApprove == options.IsApprove && i.Active == options.Active && i.IsLock == options.IsLock);
  }
}
