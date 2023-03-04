using BAS24.Auth.Infrastructure.Services.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BAS24.Auth.Infrastructure.Services;

public class SendGridService:ISendGridService
{
  private readonly ISendGridClient _sendGridClient;

  public SendGridService(ISendGridClient sendGridClient)
  {
    _sendGridClient = sendGridClient;
  }

  public async Task SendEmailAsync(SendGridMessage msg)
  {
    await _sendGridClient.SendEmailAsync(msg);
  }
}
