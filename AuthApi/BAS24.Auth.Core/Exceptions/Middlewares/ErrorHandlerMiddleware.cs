using BAS24.Libs.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BAS24.Api.Exceptions.Middlewares;

public class ErrorHandlerMiddleware
{
  private readonly ILogger<ErrorHandlerMiddleware> _logger;
  private readonly RequestDelegate _next;

  public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
  {
    _next = next;
    _logger = logger;
  }

  public async Task Invoke(HttpContext context)
  {
    try
    {
      await _next(context);
    }
    catch (Exception exception)
    {
      var additionalData = new object();
      var statusCode = 400;
      var code = string.Empty;
      if (exception is BaseException baseException)
      {
        additionalData = baseException.AdditionalData;
        statusCode = baseException.StatusCode;
        code = baseException.Code;
      }

      _logger.LogError(exception, $"{exception.Message}{{@AdditionalData}}", additionalData);
      await HandleErrorAsync(context, exception, statusCode, code);
    }
  }

  private static Task HandleErrorAsync(HttpContext context, Exception exception, int statusCode, string code)
  {
    var response = new { code, message = exception.Message };
    var payload = JsonConvert.SerializeObject(response,
      new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
    context.Response.ContentType = "application/json";
    context.Response.StatusCode = statusCode;
    return context.Response.WriteAsync(payload);
  }
}
