using BAS24.Api.Dtos.Stores;
using BAS24.Api.IRepositories;
using BAS24.Api.IServices;
using BAS24.Api.Kafka.Constants;
using BAS24.Api.Kafka.Models.Stores;
using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores.Handlers;

public class UpdateRoleOfStoreMemberCommandHandler : ICommandHandler<UpdateRoleOfStoreMemberCommand, Guid>
{
  private readonly IStoreRepository _repository;
  private readonly IKafkaProducerService _producer;

  public UpdateRoleOfStoreMemberCommandHandler(IStoreRepository repository, IKafkaProducerService producer)
  {
    _repository = repository;
    _producer = producer;
  }

  public async Task HandleAsync(UpdateRoleOfStoreMemberCommand command, Guid id)
  {
    var dto = new UpdateRoleOfStoreMemberDto()
    {
      StoreId = command.StoreId,
      MemberStoreId = command.StoreMemberId,
      Permission = command.Permission
    };
    var data = new KafkaUpdateMemberStorePermissionModel()
    {
      StoreId = dto.StoreId,
      MemberStoreId = dto.MemberStoreId,
      MemberId = id,
      Permission = dto.Permission
    };
    await _producer.SendAsync(data, KafkaTopics.UpdateStoreMemberPermission);
    await _repository.UpdateUserStoreRoleAsync(id, dto);
  }
}
