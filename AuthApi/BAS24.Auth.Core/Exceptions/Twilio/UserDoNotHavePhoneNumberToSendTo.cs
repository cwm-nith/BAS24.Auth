using BAS24.Libs.Exceptions;

namespace BAS24.Api.Exceptions.Twilio;

public class UserDoNotHavePhoneNumberToSendTo:BaseException
{
  public override string Code => "user_do_not_have_phone_number";
}
