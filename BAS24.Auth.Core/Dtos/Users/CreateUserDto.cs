namespace BAS24.Api.Dtos.Users;

public class CreateUserDto
{
  public CreateUserDto(
    string username,
    string password,
    string? fullname,
    string[]? phones,
    string? address,
    string? regionName)
  {
    Username = username;
    Password = password;
    Fullname = fullname;
    Phones = phones;
    Address = address;
    RegionName = regionName;
  }

  public string Username { get; set; }

  public string Password { get; set; }

  public string? Fullname { get; set; }

  public string[]? Phones { get; set; }

  public string? Address { get; set; }

  public string? RegionName { get; set; }
}
