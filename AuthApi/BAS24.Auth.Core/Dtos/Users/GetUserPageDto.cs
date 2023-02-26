namespace BAS24.Api.Dtos.Users;

public class GetUserPageDto
{
  public int Page { get; set; } = 1;
  public int Results { get; set; } = 10;
}
