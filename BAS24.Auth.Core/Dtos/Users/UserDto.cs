using BAS24.Api.Entities.User;

namespace BAS24.Api.Dtos.Users;

public class UserDto
{
  public string Id { get; set; }
  public string Username { get; set; }
  public string? Fullname { get; set; }
  public string? Address { get; set; }
  public bool IsLock { get; set; }
  public bool IsApprove { get; set; }
  public string? RegionName { get; set; }
  public string? Token { get; set; }
  public bool Active { get; set; }

  public static UserDto FromEntity(UserEntity entity)
  {
    return new UserDto
    {
      Fullname = entity.Fullname,
      Id = entity.Id.ToString(),
      Address = entity.Address,
      Username = entity.Username,
      IsLock = entity.IsLock,
      IsApprove = entity.IsApprove,
      RegionName = entity.RegionName
    };
  }
}
