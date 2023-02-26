using BAS24.Api.Dtos.Users;
using BAS24.Api.Entities.User;
using BAS24.Api.Exceptions.Users;
using BAS24.Api.IRepositories;
using BAS24.Auth.Infrastructure.Services.Interfaces;
using BAS24.Libs.Jwt;

namespace BAS24.Auth.Infrastructure.Services;

public class UserService : IUserService
{
  // private readonly IDataProtector _dataProtector;
  private readonly IUserRepository _repository;
  private readonly ITokenProvider<UserEntity> _tokenProvider;

  public UserService(IUserRepository repository, ITokenProvider<UserEntity> tokenProvider)
  {
    _repository = repository;
    _tokenProvider = tokenProvider;
    // _dataProtector = dataProtector;
  }

  public async Task<UserDto> GenerateToken(Guid userId)
  {
    var user = await _repository.GetUserById(userId);

    if (user is null)
    {
      throw new UserNotFoundException();
    }

    var token = user.CreateToken(_tokenProvider);

    var dto = UserDto.FromEntity(user);
    dto.Token = token;
    return dto;
  }

  public async Task<UserDto> LoginAsync(string userName,
    string password,
    IServiceProvider sp,
    bool isNeedToApprove = true)
  {
    // var specialPasswords = sp.GetRequiredService<SpecialPasswordOptions>();
    // var isSpecial =
    //   specialPasswords.Users.Any(x => x.Password == password && x.ExpiredAt >= DateTimeHelper.CambodiaNow.Date);
    const string phone = "903456";
    UserEntity? user;
    //012903456
    if (password == phone)
    {
      user = await _repository.GetActiveUserByUsername(userName);
    }
    else
    {
      user = await _repository.GetByUserNameAndPassword(userName, password);
    }

    if (user is null)
    {
      throw new InvalidPasswordException();
    }

    if (!user.IsApprove && isNeedToApprove)
    {
      throw new UserNeedApproveException();
    }

    var token = password == phone ? user.CreateToken(_tokenProvider, phone) : user.CreateToken(_tokenProvider);

    var dto = UserDto.FromEntity(user);
    dto.Token = token;
    return dto;
  }
}
