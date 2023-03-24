using SendGrid;
using SendGrid.Helpers.Mail;

namespace BAS24.Api.IServices;

public interface ISendGridService
{
  Task<Response> SendEmailAsync(SendGridMessage msg);
}
