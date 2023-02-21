namespace BAS24.Api.Dtos.Users;

public class UpdateUserDto
{
  public string? Username { get; set; }

  public string? Fullname { get; set; }

  public string[]? Phones { get; set; }

  public string? Address { get; set; }

  public string? RegionName { get; set; }
}
