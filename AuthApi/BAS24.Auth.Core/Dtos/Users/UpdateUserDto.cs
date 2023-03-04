namespace BAS24.Api.Dtos.Users;

public class UpdateUserDto
{
  public string? Username { get; set; }

  public string? Fullname { get; set; }

  public string? Phone { get; set; }
  public string? Email { get; set; }

  public string? Address { get; set; }

  public string? RegionName { get; set; }
}
