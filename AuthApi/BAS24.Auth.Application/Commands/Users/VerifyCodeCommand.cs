using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Users;

public class VerifyCodeCommand : ICommand
{
  public VerifyCodeCommand(string code, string to)
  {
    Code = code;
    To = to;
  }

  public string Code { get; set; }
  public string To { get; set; }
}
