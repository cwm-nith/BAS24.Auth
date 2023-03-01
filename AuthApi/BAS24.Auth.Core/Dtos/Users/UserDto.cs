using BAS24.Api.Entities.User;

namespace BAS24.Api.Dtos.Users;

public class UserDto
{
  public UserDto(string id, string username, bool isLock, bool isApprove)
  {
    Id = id;
    Username = username;
    IsLock = isLock;
    IsApprove = isApprove;
  }

  public string Id { get; set; }
  public string Username { get; set; }
  public string? Fullname { get; set; }
  public string? Address { get; set; }
  public bool IsLock { get; set; }
  public bool IsApprove { get; set; }
  public string? RegionName { get; set; }
  public string? Token { get; set; }
  public bool? Active { get; set; }

  public static UserDto FromEntity(UserEntity entity)
  {
    return new UserDto(id: entity.Id.ToString(),
      username: entity.Username,
      isLock: entity.IsLock,
      isApprove: entity.IsApprove)
    {
      Fullname = entity.Fullname,
      Address = entity.Address,
      RegionName = entity.RegionName,
      Active = entity.Active,
    };
  }
}
