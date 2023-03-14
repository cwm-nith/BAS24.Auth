using Microsoft.AspNetCore.Mvc;

namespace BAS24.Product.Api.Controllers.V1;

public class CurrencyController : BaseController
{
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
}
