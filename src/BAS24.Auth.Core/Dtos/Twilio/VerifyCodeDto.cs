namespace BAS24.Api.Dtos.Twilio;

public class VerifyCodeDto
{
  public VerifyCodeDto(string code)
  {
    Code = code;
  }

  public string Code { get; set; }
}
