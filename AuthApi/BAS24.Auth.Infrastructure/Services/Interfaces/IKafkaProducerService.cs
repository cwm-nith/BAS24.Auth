namespace BAS24.Auth.Infrastructure.Services.Interfaces;

public interface IKafkaProducerService
{
  Task<bool> SendAsync<T>(T data, string topic) where T : class;
}
