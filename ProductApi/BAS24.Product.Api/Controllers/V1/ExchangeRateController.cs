using BAS24.Libs.CQRS.Commands;
using BAS24.Libs.CQRS.Queries;
using BAS24.Libs.Postgres;
using BAS24.Product.Application.Commands.ExchangeRate;
using BAS24.Product.Application.Queries.ExchangeRates;
using BAS24.Product.Core.Dtos.ExchangeRate;
using BAS24.Product.Core.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BAS24.Product.Api.Controllers.V1;

public class ExchangeRateController : BaseController
{
  private readonly ICommandDispatcher _command;
  private readonly IQueryDispatcher _query;

  public ExchangeRateController(IQueryDispatcher query, ICommandDispatcher command)
  {
    _query = query;
    _command = command;
  }

  /// <summary>
  /// Create Exchange Rate
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status201Created)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [HttpPost]
  public async Task<ActionResult> CreateAsync([FromBody] CreateExchangeDto dto)
  {
    var id = GuidHelper.NewId;
    var cmd = new CreateExchangeRateCommand()
    {
      Id = id.ToGuid(),
      Rate = dto.Rate,
      CurrencyId = dto.CurrencyId,
      SetRate = dto.SetRate,
      BaseSetRate = dto.BaseSetRate,
      LocalSetRate = dto.LocalSetRate,
    };
    await _command.PerformAsync(cmd);
    return AcceptedWithResource("exchangeRate", id);
  }

  /// <summary>
  /// Update exchange rate
  /// </summary>
  /// <param name="id"></param>
  /// <param name="dto"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [HttpPut("{id:guid}")]
  public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] UpdateExchangeRateDto dto)
  {
    var cmd = new UpdateExchangeRateCommand()
    {
      Id = id,
      Rate = dto.Rate,
      SetRate = dto.SetRate,
      BaseSetRate = dto.BaseSetRate,
      LocalSetRate = dto.LocalSetRate
    };
    await _command.PerformAsync(cmd);
    return Ok();
  }

  /// <summary>
  /// Delete exchange rate
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [HttpDelete("{id:guid}")]
  public async Task<ActionResult> DeleteAsync(Guid id)
  {
    var cmd = new DeleteExchangeRateCommand();
    await _command.PerformAsync(cmd, id);
    return Ok();
  }

  /// <summary>
  /// Get all exchange rates
  /// </summary>
  /// <param name="page"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [HttpGet]
  public async Task<ActionResult<PagedResult<ExchangeRateDto>>> GetAllAsync([FromQuery] PagedQuery page)
  {
    var q = new GetAllExchangeRateQuery()
    {
      Page = page.Page,
      Results = page.Results
    };
    var data = await _query.QueryAsync<GetAllExchangeRateQuery, PagedResult<ExchangeRateDto>>(q);
    return Ok(data);
  }
}
