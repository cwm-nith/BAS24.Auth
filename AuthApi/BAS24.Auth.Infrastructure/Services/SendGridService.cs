using BAS24.Api.Exceptions.SendGrids;
using BAS24.Api.IServices;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BAS24.Auth.Infrastructure.Services;

public class SendGridService:ISendGridService
{
  private readonly ISendGridClient _sendGridClient;
  private readonly IConfiguration _configuration;
  public SendGridService(ISendGridClient sendGridClient, IConfiguration configuration)
  {
    _sendGridClient = sendGridClient;
    _configuration = configuration;
  }

  public async Task<Response> SendEmailAsync(SendGridMessage msg)
  {
    var from = _configuration["SendGrid:FromEmail"];
    var fromName = _configuration["SendGrid:FromName"];
    if (string.IsNullOrEmpty(from)) throw new InvalidEmailFromException();
    if (string.IsNullOrEmpty(fromName)) throw new InvalidNameFromException();
    
    msg.From = new EmailAddress(from, fromName);
    return await _sendGridClient.SendEmailAsync(msg);
  }
}
