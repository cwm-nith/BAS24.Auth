using BAS24.Api.Dtos.Twilio;
using BAS24.Api.Exceptions.Twilio;
using BAS24.Api.Exceptions.Users;
using BAS24.Api.IRepositories;
using BAS24.Api.IServices;
using BAS24.Api.Utils;
using BAS24.Auth.Application.Queries.Users;
using BAS24.Libs.CQRS.Queries;
using SendGrid.Helpers.Mail;

namespace BAS24.Auth.Infrastructure.QueryHandlers.Users;

public class GetCodeSmsQueryHandler : IQueryHandler<GetCodeSmsQuery, SmsDto>
{
  private readonly ITwilioRepository _repository;
  private readonly IUserRepository _userRepository;
  private readonly ISendGridService _sendGridService;

  public GetCodeSmsQueryHandler(ITwilioRepository repository, IUserRepository userRepository, ISendGridService sendGridService)
  {
    _userRepository = userRepository;
    _sendGridService = sendGridService;
    _repository = repository;
  }

  public async Task<SmsDto> HandleAsync(GetCodeSmsQuery query)
  {
    if (query.To is null)
    {
      throw new ToNumberNotValidException();
    }

    if (query.To.Contains('@'))
    {
      return await SendByEmailAsync(query);
    }
    // else if (query.To.Contains('+'))
    // {
    //   return await SendByPhoneNumberAsync(query);
    // }

    return await SendByPhoneNumberAsync(query);
  }

  private async Task<SmsDto> SendByPhoneNumberAsync(GetCodeSmsQuery query)
  {
    var user = await _userRepository.GetUserByPhoneNumberAsync(query.To);
    if (user is null)
    {
      throw new UserNotFoundException();
    }

    var code = GenerateRandomNumber.Create(8);

    try
    {
      var data = await _repository.RequestAsync(new SendSmsDto(query.To, code));

      if (data is null)
      {
        throw new CodeSendFailedException();
      }

      user.Code = code;
      await _userRepository.UpdateUserAsync(user);
      return new SmsDto(data.Body);
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      throw new FailedToSendCodeException();
    }
  }
  private async Task<SmsDto> SendByEmailAsync(GetCodeSmsQuery query)
  {
    var user = await _userRepository.GetUserByEmailAsync(query.To);
    if (user is null)
    {
      throw new UserNotFoundException();
    }

    var code = GenerateRandomNumber.Create(8);

    try
    {
      var msg = new SendGridMessage()
      {
        PlainTextContent = code,
        Subject = code,
      };
      msg.AddTo(new EmailAddress(user.Email));
      var data = await _sendGridService.SendEmailAsync(msg);

      if (!data.IsSuccessStatusCode)
      {
        throw new CodeSendFailedException();
      }

      user.Code = code;
      await _userRepository.UpdateUserAsync(user);
      return new SmsDto(code);
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      throw new FailedToSendCodeException();
    }
  }
}
