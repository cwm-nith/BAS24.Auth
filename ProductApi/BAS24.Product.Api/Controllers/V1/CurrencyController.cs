using BAS24.Libs.CQRS.Commands;
using BAS24.Libs.CQRS.Queries;
using BAS24.Libs.Postgres;
using BAS24.Product.Application.Commands.Currency;
using BAS24.Product.Application.Queries.Currency;
using BAS24.Product.Core.Dtos.Currency;
using BAS24.Product.Core.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BAS24.Product.Api.Controllers.V1;

public class CurrencyController : BaseController
{
  private readonly ICommandDispatcher _command;
  private readonly IQueryDispatcher _query;

  public CurrencyController(ICommandDispatcher command, IQueryDispatcher query)
  {
    _command = command;
    _query = query;
  }

  /// <summary>
  /// Create Currency base on store owner or store admin
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status201Created)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [HttpPost]
  public async Task<ActionResult> AddAsync([FromBody] AddCurrencyDto dto)
  {
    var id = GuidHelper.NewId.ToGuid();
    var cmd = new AddCurrencyCommand(
      id: id,
      storeOwnerId: UserId.ToGuid(),
      symbol: dto.Symbol,
      description: dto.Description,
      active: true,
      baseCurrency: dto.BaseCurrency,
      localCurrency: dto.LocalCurrency
    );
    await _command.PerformAsync(cmd);
    return AcceptedWithResource("currency", id.ToString());
  }

  /// <summary>
  /// Update currency by id, store owner and store admin
  /// </summary>
  /// <param name="id"></param>
  /// <param name="dto"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [HttpPut("{id:guid}")]
  public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] UpdateCurrencyDto dto)
  {
    var cmd = new UpdateCurrencyCommand(
      id: id,
      symbol: dto.Symbol,
      description: dto.Description,
      active: dto.Active
    );
    await _command.PerformAsync(cmd, UserId.ToGuid());
    return Ok();
  }

  /// <summary>
  /// Get all currency
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [HttpGet]
  public async Task<ActionResult<PagedResult<CurrencyDto>>> GetAllAsync([FromQuery] PagedQuery dto)
  {
    var q = new GetCurrenciesQuery()
    {
      Page = dto.Page,
      Results = dto.Results
    };
    var data = await _query.QueryAsync<GetCurrenciesQuery, PagedResult<CurrencyDto>>(q);
    return Ok(data);
  }

  /// <summary>
  /// Get active currencies by store
  /// </summary>
  /// <param name="storeId"></param>
  /// <param name="dto"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [HttpGet("{storeId:guid}/active")]
  public async Task<ActionResult<PagedResult<CurrencyDto>>> GetAllActiveByStoreAsync(Guid storeId,
    [FromQuery] GetAllActiveByStoreDto dto)
  {
    var q = new GetAllActiveByStoreQuery()
    {
      StoreId = storeId,
      Page = dto.Page,
      Results = dto.Results
    };
    var data = await _query.QueryAsync<GetAllActiveByStoreQuery, PagedResult<CurrencyDto>>(q);
    return Ok(data);
  }
  
  /// <summary>
  /// Get all currencies by store
  /// </summary>
  /// <param name="storeId"></param>
  /// <param name="dto"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [HttpGet("{storeId:guid}/all")]
  public async Task<ActionResult<PagedResult<CurrencyDto>>> GetAllByStoreAsync(Guid storeId,
    [FromQuery] GetAllActiveByStoreDto dto)
  {
    var q = new GetAllByStoreQuery()
    {
      StoreId = storeId,
      Page = dto.Page,
      Results = dto.Results
    };
    var data = await _query
      .QueryAsync<GetAllByStoreQuery, PagedResult<CurrencyDto>>(q);
    return Ok(data);
  }
  /// <summary>
  /// Get currency by Id
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [HttpGet("{id:guid}")]
  public async Task<ActionResult<CurrencyDto>> GetByIdAsync(Guid id)
  {
    var q = new GetCurrencyByIdQuery()
    {
      Id = id,
    };
    var data = await _query
      .QueryAsync<GetCurrencyByIdQuery, CurrencyDto>(q);
    return Ok(data);
  }
  
  /// <summary>
  /// Get base currency by store
  /// </summary>
  /// <param name="storeId"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [HttpGet("{storeId:guid}/base")]
  public async Task<ActionResult<CurrencyDto>> GetBaseCurrencyAsync(Guid storeId)
  {
    var q = new GetBaseCurrencyQuery()
    {
      StoreId = storeId,
    };
    var data = await _query
      .QueryAsync<GetBaseCurrencyQuery, CurrencyDto>(q);
    return Ok(data);
  }
  
  /// <summary>
  /// Get local currency by store
  /// </summary>
  /// <param name="storeId"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [HttpGet("{storeId:guid}/local")]
  public async Task<ActionResult<CurrencyDto>> GetLocalCurrencyAsync(Guid storeId)
  {
    var q = new GetLocalCurrencyQuery()
    {
      StoreId = storeId,
    };
    var data = await _query
      .QueryAsync<GetLocalCurrencyQuery, CurrencyDto>(q);
    return Ok(data);
  }

  /// <summary>
  /// Delete currency
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [HttpDelete("{id:guid}")]
  public async Task<ActionResult> DeleteAsync(Guid id)
  {
    var cmd = new DeleteCurrencyCommand() { Id = id, OwnerId = UserId.ToGuid()};
    await _command.PerformAsync(cmd);
    return Ok();
  }
}
