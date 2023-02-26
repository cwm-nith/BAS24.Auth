using BAS24.Api.Exceptions;
using BAS24.Api.Exceptions.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BAS24.Api.Middlewares;

public sealed class AuthorizationRequestHandlerMiddleware
{
  private readonly ILogger<ErrorHandlerMiddleware> _logger;
  private readonly RequestDelegate _next;

  public AuthorizationRequestHandlerMiddleware(
    RequestDelegate next,
    ILogger<ErrorHandlerMiddleware> logger)
  {
    _next = next;
    _logger = logger;
  }

  public Task Invoke(HttpContext context)
  {
    var path = context.Request.Path.Value;
    if (path != null && path.Contains("api/webhook/"))
    {
      return _next(context);
    }

    var clientHeader = context.Request.Headers["X-Client"].ToString();
    AppSettings.ClientHeaders.TryGetValue(clientHeader, out var client);
    if (string.IsNullOrEmpty(client))
    {
      throw new UnAuthorizedRequestException();
    }

    _logger.LogInformation("Requested Client {@Client}", client);
    return _next(context);
  }
}
