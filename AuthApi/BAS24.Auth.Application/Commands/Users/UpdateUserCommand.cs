using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Users;

public class UpdateUserCommand : ICommand
{
  public UpdateUserCommand(Guid id,
    string? username,
    string? fullname,
    string? phone,
    string? address,
    string? regionName,
    string? email)
  {
    Id = id;
    Username = username;
    Fullname = fullname;
    Phone = phone;
    Address = address;
    RegionName = regionName;
    Email = email;
  }

  public Guid Id { get; set; }
  public string? Username { get; set; }

  public string? Fullname { get; set; }

  public string? Phone { get; set; }

  public string? Email { get; set; }

  public string? Address { get; set; }

  public string? RegionName { get; set; }
}
