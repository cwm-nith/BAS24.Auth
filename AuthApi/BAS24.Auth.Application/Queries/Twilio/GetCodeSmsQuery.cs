using BAS24.Api.Dtos.Twilio;
using BAS24.Libs.CQRS.Queries;

namespace Application.Queries.Twilio;

public class GetCodeSmsQuery : IQuery<SmsDto>
{
  public GetCodeSmsQuery(string to)
  {
    To = to;
  }

  public string To { get; set; }
}
