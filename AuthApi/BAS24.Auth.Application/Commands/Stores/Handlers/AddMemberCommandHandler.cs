using BAS24.Api.Dtos.Stores;
using BAS24.Api.IRepositories;
using BAS24.Api.IServices;
using BAS24.Api.Kafka.Constants;
using BAS24.Api.Kafka.Models.Stores;
using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores.Handlers;

public class AddMemberCommandHandler : ICommandHandler<AddMemberCommand, Guid>
{
  private readonly IStoreRepository _storeRepository;
  private readonly IKafkaProducerService _producer;

  public AddMemberCommandHandler(IStoreRepository storeRepository, IKafkaProducerService producer)
  {
    _storeRepository = storeRepository;
    _producer = producer;
  }

  public async Task HandleAsync(AddMemberCommand command, Guid id)
  {
    var cmd = new AddMemberDto()
    {
      Permission = command.Permission,
      MemberId = command.MemberId,
      StoreId = command.StoreId,
    };
    var data = new KafkaAddMemberToStoreModel()
    { 
      Permission = cmd.Permission,
      MemberId = cmd.MemberId,
      StoreId = cmd.StoreId,
      OwnerId = id,
    };
    await _producer.SendAsync(data, KafkaTopics.AddMemberToStore);
    await _storeRepository.AddUserToStoreAsync(id, cmd);
  }
}
