using BAS24.Libs.Exceptions;

namespace BAS24.Api.Exceptions.Users;

public class FailedToCreateTokenException : BaseException
{
  public FailedToCreateTokenException(string message) : base(message)
  {
  }

  public FailedToCreateTokenException(string message, Exception innerException) : base(message, innerException)
  {
  }

  public FailedToCreateTokenException() : base("Failed to generate token")
  {
  }

  public override string Code => "failed_generate_token";
}
