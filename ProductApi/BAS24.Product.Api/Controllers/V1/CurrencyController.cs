using BAS24.Libs.CQRS.Commands;
using BAS24.Libs.CQRS.Queries;
using BAS24.Libs.Postgres;
using BAS24.Product.Application.Commands.Currency;
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
  /// Get Currency
  /// </summary>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [HttpGet]
  public ActionResult Get()
  {
    return Ok(new { Name = "Sokcheanith", Age = 21 });
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
}
