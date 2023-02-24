using BAS24.Libs.Exceptions;

namespace BAS24.Api.Exceptions.Twilio;

public class CodeSendFailedException : BaseException
{
  public override string Code => "code_send_failed";
}
