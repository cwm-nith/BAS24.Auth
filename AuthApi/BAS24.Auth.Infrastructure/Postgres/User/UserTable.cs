using System.ComponentModel.DataAnnotations.Schema;
using BAS24.Libs.Postgres;

namespace Infra.Postgres.User;

public class UserTable : BasePostgresTable
{
  public UserTable(
    string username,
    string password,
    string? fullname,
    string[]? phones,
    bool? active,
    string? address,
    bool? isLock,
    bool isApprove,
    string? regionName,
    DateTime createdAt,
    DateTime updatedAt,
    string? code)
  {
    Username = username;
    Password = password;
    CreatedAt = createdAt;
    Fullname = fullname;
    Phones = phones;
    Active = active;
    IsApprove = isApprove;
    Address = address;
    IsLock = isLock;
    RegionName = regionName;
    UpdatedAt = updatedAt;
    Code = code;
  }

  [Column("username")]
  public string Username { get; set; }

  [Column("code")]
  public string? Code { get; set; }

  [Column("password")]
  public string Password { get; set; }

  [Column("fullname")]
  public string? Fullname { get; set; }

  [Column("phones")]
  public string[]? Phones { get; set; }

  [Column("active")]
  public bool? Active { get; set; }

  [Column("address")]
  public string? Address { get; set; }

  [Column("is_lock")]
  public bool? IsLock { get; set; }

  [Column("is_approve")]
  public bool IsApprove { get; set; }

  [Column("region_name")]
  public string? RegionName { get; set; }

  [Column("created_at")]
  public DateTime CreatedAt { get; set; }

  [Column("updated_at")]
  public DateTime UpdatedAt { get; set; }
}
