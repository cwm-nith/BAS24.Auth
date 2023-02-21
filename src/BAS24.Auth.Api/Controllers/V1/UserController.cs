using BAS24.Api.Dtos.Users;
using BAS24.Api.Utils;
using BAS24.Auth.Application.Commands.Users;
using BAS24.Auth.Infrastructure.Services.Interfaces;
using BAS24.Libs.CQRS.Commands;
using BAS24.Libs.CQRS.Queries;
using BAS24.Libs.Postgres;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BAS24.Auth.Api.Controllers.V1;

public class UserController : BaseController
{
  private readonly ICommandDispatcher _command;
  private readonly IQueryDispatcher _query;
  private readonly IServiceProvider _serviceProvider;
  private readonly IUserService _userService;

  public UserController(ICommandDispatcher command,
    IUserService userService,
    IQueryDispatcher query,
    IServiceProvider serviceProvider)
  {
    _command = command;
    _userService = userService;
    _query = query;
    _serviceProvider = serviceProvider;
  }

  [AllowAnonymous]
  [HttpPost]
  [ProducesResponseType(StatusCodes.Status202Accepted)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesDefaultResponseType]
  public async Task<ActionResult> CreateAsync([FromBody] CreateUserDto dto)
  {
    var id = GuidHelper.NewId;

    await _command.PerformAsync(new CreateUserCommand(id.ToGuid(),
      dto.Username,
      dto.Password,
      dto.Fullname,
      dto.Phones,
      dto.Address,
      dto.RegionName));
    return AcceptedWithResource("user", id);
  }
}
