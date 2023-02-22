using BAS24.Api.Dtos.Users;

namespace BAS24.Auth.Infrastructure.Services.Interfaces;

public interface IUserService
{
  Task<UserDto> LoginAsync(string userName, string password, IServiceProvider sp, bool isNeedToApprove = true);

  Task<UserDto> GenerateToken(Guid userId);
}
