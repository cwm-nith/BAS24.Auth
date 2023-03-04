namespace BAS24.Api.Dtos.Users;

public class CreateUserDto
{
  public CreateUserDto(
    string username,
    string password,
    string? fullname,
    string? phone,
    string? address,
    string? regionName,
    string? email)
  {
    Username = username;
    Password = password;
    Fullname = fullname;
    Phone = phone;
    Address = address;
    RegionName = regionName;
    Email = email;
  }

  public string Username { get; set; }

  public string Password { get; set; }

  public string? Fullname { get; set; }

  public string? Phone { get; set; }
  public string? Email { get; set; }

  public string? Address { get; set; }

  public string? RegionName { get; set; }
}
