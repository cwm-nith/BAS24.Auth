using BAS24.Api.Dtos.Twilio;
using BAS24.Api.Entities.User;
using BAS24.Api.Exceptions.Twilio;
using BAS24.Api.Exceptions.Users;
using BAS24.Api.IRepositories;
using Microsoft.Extensions.Configuration;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace BAS24.Auth.Infrastructure.Repositories;

public class TwilioRepository : ITwilioRepository
{
  private readonly PhoneNumber _phoneFrom;
  private readonly IUserRepository _repository;
  private readonly ITwilioRestClient _twilioRestClient;


  public TwilioRepository(ITwilioRestClient twilioRestClient, IConfiguration configuration, IUserRepository repository)
  {
    _repository = repository;
    _twilioRestClient = twilioRestClient;
    _phoneFrom = configuration["Twilio:From"];
  }

  public MessageResource Request(SendSmsDto dto)
  {
    var message = MessageResource.Create(from: _phoneFrom,
      to: new PhoneNumber(dto.To),
      body: dto.Message,
      client: _twilioRestClient);
    return message;
  }

  public async Task VerifyCodeAsync(string code, string to)
  {
    UserEntity? user;
    if (to.Contains('@'))
    {
      user = await _repository.GetUserByEmailAsync(to);
    }
    else if(to.Contains('+'))
    {
      user = await _repository.GetUserByPhoneNumber(to);
    }
    else
    {
      throw new InvalidSendToException();
    }
    if (user is null)
    {
      throw new UserNotFoundException();
    }

    if (user.Code == code)
    {
      user.IsApprove = true;
      user.Active = true;
      user.Code = null;
      await _repository.UpdateUser(user);
    }
  }

  public async Task<MessageResource> RequestAsync(SendSmsDto dto)
  {
    var message = await MessageResource.CreateAsync(from: _phoneFrom,
      to: new PhoneNumber(dto.To),
      body: dto.Message,
      client: _twilioRestClient);
    return message;
  }
}
