namespace BAS24.Auth.Infrastructure.Services.Interfaces;

public interface IKafkaProducers
{
  Task<bool> SendAsync<T>(T data, string topic) where T : class;
}
