using BAS24.Libs.CQRS.Commands;
using BAS24.Libs.CQRS.Queries;
using BAS24.Libs.Postgres;
using BAS24.Product.Application.Commands.ExchangeRate;
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
      BaseSetRate = dto.SetRate,
      LocalSetRate = dto.LocalSetRate
    };
    await _command.PerformAsync(cmd);
    return AcceptedWithResource("exchangeRate", id);
  }
}
