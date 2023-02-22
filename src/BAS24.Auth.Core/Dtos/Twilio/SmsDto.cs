namespace BAS24.Api.Dtos.Twilio;

public class SmsDto
{
  public SmsDto(string code)
  {
    Code = code;
  }

  public string Code { get; set; }
}
