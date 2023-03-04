using BAS24.Api.Dtos.Twilio;
using BAS24.Api.Exceptions.Twilio;
using BAS24.Api.Exceptions.Users;
using BAS24.Api.IRepositories;
using BAS24.Api.Utils;
using BAS24.Auth.Application.Queries.Twilio;
using BAS24.Auth.Infrastructure.Services.Interfaces;
using BAS24.Libs.CQRS.Queries;

namespace BAS24.Auth.Infrastructure.QueryHandlers.Twilio;

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
      
    }else if (query.To.Contains('+'))
    {
      return await SendByPhoneNumberAsync(query);
    }

    return new SmsDto("");
  }

  private async Task<SmsDto> SendByPhoneNumberAsync(GetCodeSmsQuery query)
  {
    var user = await _userRepository.GetUserByPhoneNumber(query.To);
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
      await _userRepository.UpdateUser(user);
      return new SmsDto(data.Body);
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      throw new FailedToSendCodeException();
    }
  }
}
