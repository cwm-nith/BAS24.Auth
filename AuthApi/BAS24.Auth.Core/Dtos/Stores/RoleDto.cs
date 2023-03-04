namespace BAS24.Api.Dtos.Stores;

public class RoleDto
{
  public string Name { get; set; }
  public int Role { get; set; }
  public bool IsAdmin { get; set; }

  public RoleDto(string name, int role, bool isAdmin)
  {
    Name = name;
    Role = role;
    IsAdmin = isAdmin;
  }
}
