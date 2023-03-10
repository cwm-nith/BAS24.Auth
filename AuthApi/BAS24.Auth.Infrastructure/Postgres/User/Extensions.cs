using BAS24.Api.Entities.User;

namespace BAS24.Auth.Infrastructure.Postgres.User;

public static class Extensions
{
  public static UserTable AsTable(this UserEntity e)
  {
    return new UserTable(
      e.Username,
      e.PasswordHash,
      createdAt: e.CreatedAt,
      fullname: e.Fullname,
      phone: e.Phone,
      active: e.Active,
      address: e.Address,
      isLock: e.IsLock,
      isApprove: e.IsApprove,
      regionName: e.RegionName,
      updatedAt: e.UpdatedAt,
      code: e.Code
    )
    {
      Id = e.Id,
      Email = e.Email,
    };
  }

  public static UserEntity AsEntity(this UserTable t)
  {
    return new UserEntity(username:t.Username)
    {
      Id = t.Id,
      Password = t.Password,
      PasswordHash = t.Password,
      Fullname = t.Fullname,
      Active = t.Active,
      CreatedAt = t.CreatedAt,
      Address = t.Address,
      Phone = t.Phone,
      IsLock = t.IsLock ?? false,
      IsApprove = t.IsApprove,
      RegionName = t.RegionName,
      UpdatedAt = t.UpdatedAt,
      Code = t.Code,
      Email = t.Email,
    };
  }
}
