using BAS24.Api.Dtos.Twilio;
using BAS24.Api.Dtos.Users;
using BAS24.Api.Utils;
using BAS24.Auth.Application.Commands.Twilio;
using BAS24.Auth.Application.Commands.Users;
using BAS24.Auth.Application.Queries.Twilio;
using BAS24.Auth.Application.Queries.Users;
using BAS24.Auth.Infrastructure.Services.Interfaces;
using BAS24.Libs.CQRS.Commands;
using BAS24.Libs.CQRS.Queries;
using BAS24.Libs.Jwt;
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
    var userDto = await _userService.LoginAsync(dto.Username, dto.Password, _serviceProvider, false);
    var token = new JsonWebToken { AccessToken = userDto.Token ?? string.Empty };
    return OkWithResource(token, $"user/{userDto.Id}", userDto.Id);
  }

  /// <summary>
  ///   user login
  /// </summary>
  /// <param name="login"></param>
  /// <returns></returns>
  [HttpPost("login")]
  [AllowAnonymous]
  public async Task<ActionResult> LoginAsync([FromBody] LoginDto login)
  {
    var dto = await _userService.LoginAsync(login.Username, login.Password, _serviceProvider);
    var token = new JsonWebToken { AccessToken = dto.Token ?? string.Empty };
    return OkWithResource(token, $"user/{dto.Id}", dto.Id);
  }

  /// <summary>
  ///   update user
  /// </summary>
  /// <param name="update"></param>
  /// <returns></returns>
  [HttpPut]
  public async Task<ActionResult> UpdateUserAsync([FromBody] UpdateUserDto update)
  {
    // var dto = await _userService.LoginAsync(login.Username, login.Password, _serviceProvider);
    // var token = new JsonWebToken { AccessToken = dto.Token ?? string.Empty };

    var cmd = new UpdateUserCommand(UserId.ToGuid(),
      update.Username,
      update.Fullname,
      update.Phones,
      update.Address,
      update.RegionName);
    await _command.PerformAsync(cmd, UserId.ToGuid());
    return Accepted();
  }

  /// <summary>
  ///   remove user by id
  /// </summary>
  /// <param name="userId"></param>
  /// <returns></returns>
  [HttpDelete("{userId:Guid}")]
  [ProducesResponseType(StatusCodes.Status202Accepted)]
  [ProducesDefaultResponseType]
  public async Task<ActionResult> RemoveUserAsync(Guid userId)
  {
    var cmd = new RemoveUserCommand(userId);
    await _command.PerformAsync(cmd, UserId.ToGuid());
    return Accepted();
  }

  /// <summary>
  ///   get user list
  /// </summary>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesDefaultResponseType]
  [HttpGet]
  public async Task<ActionResult<PagedResult<UserDto>>> GetUserListAsync([FromQuery] GetUserPageDto dto)
  {
    var query = new GetUserPageQuery { Page = dto.Page, Results = dto.Results };
    var result = await _query.QueryAsync<GetUserPageQuery, PagedResult<UserDto>>(query);
    return Ok(result);
  }

  /// <summary>
  ///   Verify Code
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesDefaultResponseType]
  [HttpPost("verify")]
  public async Task<ActionResult> VerifyAsync([FromBody] VerifyCodeDto dto)
  {
    var cmd = new VerifyCodeCommand(dto.Code);
    await _command.PerformAsync(cmd, UserId);
    return Ok();
  }

  /// <summary>
  ///   Send Code
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesDefaultResponseType]
  [HttpPost("send-code")]
  public async Task<ActionResult<SmsDto>> SendCodeAsync([FromBody] SendSmsDto dto)
  {
    var q = new GetCodeSmsQuery(dto.To);
    var code = await _query.QueryAsync<GetCodeSmsQuery, SmsDto>(q);
    return Ok(code);
  }
  
  /// <summary>
  /// return current user login
  /// </summary>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesDefaultResponseType]
  [HttpGet("get-me")]
  public async Task<ActionResult<UserDto>> GetMeAsync()
  {
    var q = new GetUserByIdQuery(UserId);
    var user = await _query.QueryAsync<GetUserByIdQuery, UserDto>(q);
    return Ok(user);
  }
  
  /// <summary>
  /// return user by id specify
  /// </summary>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesDefaultResponseType]
  [HttpGet("{userId}")]
  public async Task<ActionResult<UserDto>> GetUserByIdAsync(string userId)
  {
    var q = new GetUserByIdQuery(userId);
    var user = await _query.QueryAsync<GetUserByIdQuery, UserDto>(q);
    return Ok(user);
  }
  
  /// <summary>
  /// update user by id specify
  /// </summary>
  /// <returns></returns>
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesDefaultResponseType]
  [HttpPut("{userId}")]
  public async Task<ActionResult<UserDto>> GetUserByIdAsync(string userId, [FromBody] UpdateUserDto dto)
  {
    var cmd = new UpdateUserCommand(UserId.ToGuid(),
      dto.Username,
      dto.Fullname,
      dto.Phones,
      dto.Address,
      dto.RegionName);
    await _command.PerformAsync(cmd, UserId.ToGuid());
    return Accepted();
  }
}
