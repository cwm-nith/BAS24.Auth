using BAS24.Auth.Infrastructure.Services.Interfaces;

namespace BAS24.Auth.Infrastructure.Services;

public class KafkaProducers:IKafkaProducers
{
  public Task<bool> SendAsync<T>(T data)
  {
    throw new NotImplementedException();
  }
}
