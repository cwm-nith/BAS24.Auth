using SendGrid;
using SendGrid.Helpers.Mail;

namespace BAS24.Auth.Infrastructure.Services.Interfaces;

public interface ISendGridService
{
  Task<Response> SendEmailAsync(SendGridMessage msg);
}
