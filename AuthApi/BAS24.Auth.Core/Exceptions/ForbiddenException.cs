using BAS24.Libs.Exceptions;

namespace BAS24.Api.Exceptions;

public class ForbiddenException:BaseException
{
  public override string Code => "have_not_access";

  public ForbiddenException(string message):base(message)
  {
    
  }
  public ForbiddenException()
  {
    
  }
}
