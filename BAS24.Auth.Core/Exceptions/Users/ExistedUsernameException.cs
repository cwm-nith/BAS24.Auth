using BAS24.Libs.Exceptions;

namespace BAS24.Api.Exceptions.Users;

public class ExistedUsernameException : BaseException
{
  public ExistedUsernameException(string username) : base($"Duplicate phone {username}")
  {
  }

  public ExistedUsernameException()
  {
  }

  public ExistedUsernameException(string message, Exception innerException) : base(message, innerException)
  {
  }

  public override string Code => "existed_username";
}
