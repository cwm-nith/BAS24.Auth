using BAS24.Libs.CQRS.Commands;

namespace Application.Commands.Twilio;

public class VerifyCodeCommand : ICommand
{
  public VerifyCodeCommand(string code)
  {
    Code = code;
  }

  public string Code { get; set; }
}
