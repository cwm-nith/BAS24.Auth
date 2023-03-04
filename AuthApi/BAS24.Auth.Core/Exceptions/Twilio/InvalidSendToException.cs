using BAS24.Libs.Exceptions;

namespace BAS24.Api.Exceptions.Twilio;

public class InvalidSendToException:BaseException
{
  public override string Code => "invalid_send_to";
}
