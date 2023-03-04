namespace BAS24.Api.Commons;

public class UserFilterOptions
{
  public bool Active { get; set; } = true;
  public bool IsApprove { get; set; } = true;
  public bool IsLock { get; set; } = false;
}
