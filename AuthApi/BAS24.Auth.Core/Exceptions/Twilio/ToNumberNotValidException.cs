using BAS24.Libs.Exceptions;

namespace BAS24.Api.Exceptions.Twilio;

public class ToNumberNotValidException : BaseException
{
  public ToNumberNotValidException(string to) : base($"To phone {to} is not a valid phone number!")
  {
  }

  public ToNumberNotValidException()
  {
  }

  public ToNumberNotValidException(string message, Exception innerException) : base(message, innerException)
  {
  }

  public override string Code => "to_number_not_valid";
}
