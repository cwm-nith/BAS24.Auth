using BAS24.Libs.Exceptions;

namespace BAS24.Api.Exceptions.SendGrids;

public class InvalidEmailFromException:BaseException
{
  public override string Code => "invalid_email_from";
}
