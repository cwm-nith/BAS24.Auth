using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Users;

public class CreateUserCommand : ICommand
{
  public CreateUserCommand(Guid id,
    string username,
    string password,
    string? fullname,
    string[]? phones,
    string? address,
    string? regionName)
  {
    Id = id;
    Username = username;
    Password = password;
    Fullname = fullname;
    Phones = phones;
    Address = address;
    RegionName = regionName;
  }

  public Guid Id { get; set; }
  public string Username { get; set; }

  public string Password { get; set; }

  public string? Fullname { get; set; }

  public string[]? Phones { get; set; }

  public string? Address { get; set; }

  public string? RegionName { get; set; }
}
