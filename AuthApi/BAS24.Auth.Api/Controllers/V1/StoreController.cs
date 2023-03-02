using BAS24.Api.Dtos.Stores;
using BAS24.Api.Utils;
using BAS24.Auth.Application.Commands.Stores;
using BAS24.Auth.Application.Queries.Stores;
using BAS24.Libs.CQRS.Commands;
using BAS24.Libs.CQRS.Queries;
using BAS24.Libs.Postgres;
using Microsoft.AspNetCore.Mvc;

namespace BAS24.Auth.Api.Controllers.V1;

public class StoreController : BaseController
{
  private readonly ICommandDispatcher _command;
  private readonly IQueryDispatcher _query;

  public StoreController(ICommandDispatcher command, IQueryDispatcher query)
  {
    _command = command;
    _query = query;
  }

  /// <summary>
  /// Create store
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status202Accepted)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesDefaultResponseType]
  [HttpPost]
  public async Task<ActionResult<StoreDto>> CreateStoreAsync([FromBody] CreateStoreDto dto)
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
    var query = new GetStoreByIdAndOwnerIdQuery(id.ToGuid(), cmd.OwnerId, false);
    var result = await _query.QueryAsync<GetStoreByIdAndOwnerIdQuery, StoreDto>(query);
    return OkWithResource(result,
      "store",
      id);
  }

  /// <summary>
  /// return all stores or base on owner
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesDefaultResponseType]
  [HttpGet]
  public async Task<ActionResult<PagedResult<StoreDto>>> GetStoreListAsync([FromQuery] GetStoresPageDto dto)
  {
    var query = new GetStoresPageQuery()
    {
      Page = dto.Page,
      Results = dto.Results,
      OwnerId = dto.OwnerId,
      Active = dto.Active
    };
    var result = await _query.QueryAsync<GetStoresPageQuery, PagedResult<StoreDto>>(query);
    return Ok(result);
  }

  /// <summary>
  /// return store base on its id
  /// </summary>
  /// <param name="id">store id in string</param>
  /// <param name="isActive">Default value is true</param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesDefaultResponseType]
  [HttpGet("{id}")]
  public async Task<ActionResult<StoreDto>> GetStoreByIdAsync(string id, bool isActive = true)
  {
    var query = new GetStoreByIdQuery(id.ToGuid(), isActive);
    var result = await _query.QueryAsync<GetStoreByIdQuery, StoreDto>(query);
    return Ok(result);
  }

  /// <summary>
  /// return store base on its id and owner id
  /// </summary>
  /// <param name="id"></param>
  /// <param name="ownerId"></param>
  /// <param name="isActive">Default value is true</param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesDefaultResponseType]
  [HttpGet("{id}/{ownerId}")]
  public async Task<ActionResult<StoreDto>> GetStoreByIdAndOwnerIdAsync(string id,
    string ownerId,
    [FromQuery] bool isActive = true)
  {
    var query = new GetStoreByIdAndOwnerIdQuery(id.ToGuid(), ownerId.ToGuid(), isActive);
    var result = await _query.QueryAsync<GetStoreByIdAndOwnerIdQuery, StoreDto>(query);
    return Ok(result);
  }

  /// <summary>
  /// Verify store by store owner
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [HttpPost("verify-store")]
  public async Task<ActionResult> VerifyStoreAsync([FromBody] VerifyStoreDto dto)
  {
    var cmd = new VerifyStoreCommand(dto.Code, dto.OwnerId);
    await _command.PerformAsync(cmd, dto.Id);
    return Ok();
  }

  [HttpPost("deactivate")]
  public async Task<ActionResult> DeactivateStoreAsync([FromBody] DeactivateStoreDto dto)
  {
    var cmd = new DeactivateStoreCommand(dto.OwnerId);
    await _command.PerformAsync(cmd, dto.Id);
    return Ok();
  }
}
