using BAS24.Libs.Exceptions;

namespace BAS24.Api.Exceptions.Twilio;

public class FailedToSendCodeException:BaseException
{
  public override string Code => "failed_to_send_code";
}
