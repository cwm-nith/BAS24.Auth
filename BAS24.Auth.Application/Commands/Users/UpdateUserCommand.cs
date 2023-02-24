using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Users;

public class UpdateUserCommand : ICommand
{
  public UpdateUserCommand(Guid id,
    string? username,
    string? fullname,
    string[]? phones,
    string? address,
    string? regionName)
  {
    Id = id;
    Username = username;
    Fullname = fullname;
    Phones = phones;
    Address = address;
    RegionName = regionName;
  }

  public Guid Id { get; set; }
  public string? Username { get; set; }

  public string? Fullname { get; set; }

  public string[]? Phones { get; set; }

  public string? Address { get; set; }

  public string? RegionName { get; set; }
}
