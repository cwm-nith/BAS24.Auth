namespace BAS24.Api.Dtos.Twilio;

public class VerifyCodeDto
{
  public VerifyCodeDto(string code, string to)
  {
    Code = code;
    To = to;
  }

  public string Code { get; set; }
  public string To { get; set; }
}
