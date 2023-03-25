namespace BAS24.Api.IServices;

public interface IKafkaProducerService
{
  Task<bool> SendAsync<T>(T data, string topic) where T : class;
}
