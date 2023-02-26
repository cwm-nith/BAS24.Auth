using BAS24.Libs.Exceptions;

namespace BAS24.Api.Exceptions;

public class UnAuthorizedRequestException : BaseException
{
  public UnAuthorizedRequestException() : base("Attempted to perform an unauthorized operation.") { }

  public UnAuthorizedRequestException(string message) : base(message)
  {
  }

  public UnAuthorizedRequestException(string message, Exception innerException) : base(message, innerException)
  {
  }

  public override string Code => "unauthorized";
}
