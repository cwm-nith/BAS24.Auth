namespace BAS24.Api.Dtos.Twilio;

public class SendSmsDto
{
  public SendSmsDto(string to, string? message = null)
  {
    To = to;
    Message = message;
  }

  public string To { get; set; }
  public string? Message { get; set; }
}
