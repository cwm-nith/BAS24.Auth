using BAS24.Api.Dtos.Twilio;
using BAS24.Api.Exceptions.Twilio;
using BAS24.Api.Exceptions.Users;
using BAS24.Api.IRepositories;
using BAS24.Api.Utils;
using Application.Queries.Twilio;
using BAS24.Libs.CQRS.Queries;

namespace Infra.QueryHandlers.Twilio;

public class GetCodeSmsQueryHandler : IQueryHandler<GetCodeSmsQuery, SmsDto>
{
  private readonly ITwilioRepository _repository;
  private readonly IUserRepository _userRepository;

  public GetCodeSmsQueryHandler(ITwilioRepository repository, IUserRepository userRepository)
  {
    _userRepository = userRepository;
    _repository = repository;
  }

  public async Task<SmsDto>? HandleAsync(GetCodeSmsQuery query)
  {
    if (query.To is null)
    {
      throw new ToNumberNotValidException();
    }

    var user = await _userRepository.GetActiveUserByPhoneNumber(query.To);
    if (user is null)
    {
      throw new UserNotFoundException();
    }

    var code = GenerateRandomNumber.Create(8);

    var data = await _repository.RequestAsync(new SendSmsDto(query.To, code));

    if (data is null)
    {
      throw new CodeSendFailedException();
    }

    user.Code = code;
    await _userRepository.UpdateUser(user);
    return new SmsDto(data.Body);
  }
}
