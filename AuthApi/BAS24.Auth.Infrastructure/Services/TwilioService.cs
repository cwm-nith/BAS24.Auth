using Microsoft.Extensions.Configuration;
using Twilio.Clients;
using Twilio.Http;
using HttpClient = System.Net.Http.HttpClient;
using HttpClientTwilio = Twilio.Http.HttpClient;

namespace BAS24.Auth.Infrastructure.Services;

public class TwilioService : ITwilioRestClient
{
  private readonly ITwilioRestClient _twilioRestClient;

  public TwilioService(IConfiguration configuration, HttpClient httpClient)
  {
    _twilioRestClient = new TwilioRestClient(
      configuration["Twilio:AccountSid"],
      configuration["Twilio:AuthToken"],
      httpClient: new SystemNetHttpClient(httpClient));
  }

  public HttpClientTwilio HttpClient => _twilioRestClient.HttpClient;

  public Response Request(Request request)
  {
    return _twilioRestClient.Request(request);
  }

  public Task<Response> RequestAsync(Request request)
  {
    return _twilioRestClient.RequestAsync(request);
  }

  public string AccountSid => _twilioRestClient.AccountSid;
  public string Region => _twilioRestClient.Region;
}
