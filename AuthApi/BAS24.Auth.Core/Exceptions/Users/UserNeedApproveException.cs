using BAS24.Libs.Exceptions;

namespace BAS24.Api.Exceptions.Users;

public class UserNeedApproveException : BaseException
{
  public UserNeedApproveException() : base("Account is not approve yet") { }

  public UserNeedApproveException(string message) : base(message)
  {
  }

  public UserNeedApproveException(string message, Exception innerException) : base(message, innerException)
  {
  }

  public override string Code => "user_need_approve";
}
