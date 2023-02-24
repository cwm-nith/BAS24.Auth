namespace BAS24.Api.Dtos.Users;

public class LoginDto
{
  public LoginDto(string userName, string password)
  {
    Username = userName;
    Password = password;
  }

  public string Username { get; set; }
  public string Password { get; set; }
}
