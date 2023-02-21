using BAS24.Libs.Exceptions;

namespace BAS24.Api.Exceptions.Users;

public class UserNotFoundException : BaseException
{
  public UserNotFoundException(string userId) : base($"User with id {userId} not found") { }
  public UserNotFoundException(string userId, int statusCode) : base($"User with id {userId} not found", statusCode) { }

  public UserNotFoundException()
  {
  }

  public UserNotFoundException(string message, Exception innerException) : base(message, innerException)
  {
  }

  public override string Code => "user_not_found";
}
