using BAS24.Libs.Exceptions;

namespace BAS24.Api.Exceptions.SendGrids;

public class InvalidNameFromException:BaseException
{
  public override string Code => "invalid_name_from";
}
