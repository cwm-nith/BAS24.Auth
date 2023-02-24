using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("/api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize]
public class BaseController : ControllerBase
{
  private const string ResourceHeader = "X-Resource";
  private const string IdentityHeader = "X-Identity";


  protected string UserId => User?.Identity?.Name ?? string.Empty;

  protected string UserRole
  {
    get
    {
      var pos = User?.FindFirst(ClaimTypes.Role)?.Value;
      return string.IsNullOrWhiteSpace(pos) ? "" : pos;
    }
  }

  protected ActionResult Accepted(string resource, string resourceId)
  {
    if (!string.IsNullOrWhiteSpace(resourceId))
    {
      Response.Headers.Add(ResourceHeader, $"{resource}/{resourceId}");
    }

    return base.Accepted();
  }

  protected ActionResult AcceptedWithResource(string resource, string identity)
  {
    if (string.IsNullOrWhiteSpace(resource))
    {
      return base.Accepted();
    }

    Response.Headers.Add(ResourceHeader, $"{resource}/{identity}");
    Response.Headers.Add(IdentityHeader, $"{identity}");

    return base.Accepted();
  }

  protected ActionResult OkWithResource(object obj, string resource, string identity)
  {
    if (string.IsNullOrWhiteSpace(resource))
    {
      return base.Ok(obj);
    }

    Response.Headers.Add(ResourceHeader, $"{resource}");
    Response.Headers.Add(IdentityHeader, $"{identity}");

    return base.Ok(obj);
  }
}
