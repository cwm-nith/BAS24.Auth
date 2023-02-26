using BAS24.Api.Dtos.Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace BAS24.Api.IRepositories;

public interface ITwilioRepository
{
  Task<MessageResource> RequestAsync(SendSmsDto dto);
  MessageResource Request(SendSmsDto dto);
  Task VerifyCodeAsync(string code, string userId);
}
