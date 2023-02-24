using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Twilio;

public class VerifyCodeCommand : ICommand
{
  public VerifyCodeCommand(string code)
  {
    Code = code;
  }

  public string Code { get; set; }
}
