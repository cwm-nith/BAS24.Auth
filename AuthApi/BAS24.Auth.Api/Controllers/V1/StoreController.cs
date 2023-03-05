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

  /// <summary>
  /// Deactivate store. This action is for store admin only
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [HttpPost("deactivate")]
  public async Task<ActionResult> DeactivateStoreAsync([FromBody] DeactivateStoreDto dto)
  {
    var cmd = new DeactivateStoreCommand(dto.OwnerId);
    await _command.PerformAsync(cmd, dto.Id);
    return Ok();
  }
  
  /// <summary>
  /// Activate store. This action is for store admin only
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [HttpPost("activate")]
  public async Task<ActionResult> ActivateStoreAsync([FromBody] ActivateStoreDto dto)
  {
    var cmd = new ActivateStoreCommand(dto.OwnerId);
    await _command.PerformAsync(cmd, dto.Id);
    return Ok();
  }

  /// <summary>
  /// Add member to store
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [HttpPut("add-member")]
  public async Task<ActionResult> AddMemberAsync([FromBody] AddMemberDto dto)
  {
    var cmd = new AddMemberCommand()
    {
      Permission = dto.Permission,
      StoreId = dto.StoreId,
      MemberId = dto.MemberId
    };
    await _command.PerformAsync(cmd, UserId.ToGuid());
    return Accepted();
  }

  /// <summary>
  /// Update member role
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [HttpPut("update-member-role")]
  public async Task<ActionResult> UpdateMemberRoleAsync(UpdateRoleOfStoreMemberDto dto)
  {
    var cmd = new UpdateRoleOfStoreMemberCommand()
    {
      Permission = dto.Permission,
      StoreId = dto.StoreId,
      StoreMemberId = dto.MemberStoreId
    };

    await _command.PerformAsync(cmd, UserId.ToGuid());
    return Ok();
  }

  /// <summary>
  /// Get store roles
  /// </summary>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [HttpGet("roles")]
  public async Task<ActionResult<List<RoleDto>>> GetRolesAsync()
  {
    var roleDtos = await _query.QueryAsync<GetRolesQuery, List<RoleDto>>(new GetRolesQuery());
    return Ok(roleDtos);
  }
  
  /// <summary>
  /// Return all store member (Filter: 1: all, 2: accepted, 3: not accepted)
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [HttpGet("store-members")]
  public async Task<ActionResult<PagedResult<StoreMemberDto>>> GetStoreMembersAsync([FromQuery] GetStoreMembersDto dto)
  {
    var q = new GetStoreMembersQuery()
    {
      Page = dto.Page,
      Results = dto.Results,
      StoreId = dto.StoreId,
      Filter = dto.Filter
    };
    var data = await _query
      .QueryAsync<GetStoreMembersQuery, PagedResult<StoreMemberDto>>(q);
    return Ok(data);
  }
}
