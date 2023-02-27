using BAS24.Api.Dtos.Stores;
using BAS24.Api.Utils;
using BAS24.Auth.Application.Commands.Stores;
using BAS24.Libs.CQRS.Commands;
using BAS24.Libs.CQRS.Queries;
using BAS24.Libs.Postgres;
using Microsoft.AspNetCore.Mvc;

namespace BAS24.Auth.Api.Controllers.V1;

public class StoreController:BaseController
{
  private readonly ICommandDispatcher _command;
  private readonly IQueryDispatcher _query;

  public StoreController(ICommandDispatcher command, IQueryDispatcher query)
  {
    _command = command;
    _query = query;
  }

  [HttpPost]
  public async Task<ActionResult> CreateStoreAsync([FromBody] CreateStoreDto dto)
  {
    var id = GuidHelper.NewId;
    var cmd = new CreateStoreCommand(
      id: id.ToGuid(), 
      ownerId: UserId.ToGuid(), 
      name: dto.Name, 
      description: dto.Description, 
      address: dto.Address, 
      phones: dto.Phones, 
      emails: dto.Emails, 
      tags: dto.Tags, 
      keyWords: dto.KeyWords, 
      categoryIds: dto.CategoryIds, 
      startWorkingTime: dto.StartWorkingTime, 
      endWorkingTime: dto.EndWorkingTime
      );
    await _command.PerformAsync(cmd);
    return AcceptedWithResource("store", id);
  }
}
