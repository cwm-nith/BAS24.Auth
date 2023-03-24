using BAS24.Api.Dtos.Stores;
using BAS24.Api.IRepositories;
using BAS24.Api.IServices;
using BAS24.Api.Kafka.Constants;
using BAS24.Api.Kafka.Models.Stores;
using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores.Handlers;

public class RemoveStoreMemberCommandHandler:ICommandHandler<RemoveStoreMemberCommand>
{
  private readonly IStoreRepository _storeRepository;
  private readonly IKafkaProducerService _producer;

  public RemoveStoreMemberCommandHandler(IStoreRepository storeRepository, IKafkaProducerService producer)
  {
    _storeRepository = storeRepository;
    _producer = producer;
  }

  public async Task HandleAsync(RemoveStoreMemberCommand command)
  {
    var cmd = new RemoveStoreMemberDto()
    {
      MemberId = command.MemberId,
      StoreId = command.StoreId,
      StoreMemberId = command.StoreMemberId
    };
    var data = new KafkaRemoveMemberFromStoreModel()
    {
      MemberId = cmd.MemberId,
      StoreId = cmd.StoreId,
      StoreMemberId = cmd.StoreMemberId
    };
    await _producer.SendAsync(data, KafkaTopics.RemoveStoreMember);
    await _storeRepository.RemoveUserFromStoreAsync(cmd);
  }
}
