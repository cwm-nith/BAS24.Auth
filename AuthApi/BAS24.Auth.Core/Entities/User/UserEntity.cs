using System.Security.Claims;
using BAS24.Api.Exceptions.Users;
using BAS24.Libs.Jwt;
using Microsoft.AspNetCore.Identity;

namespace BAS24.Api.Entities.User;

public class UserEntity
{
  public Guid Id { get; set; }

  public string? Code { get; set; }
  public string Username { get; set; }
  public string[]? Phones { get; set; }
  public string Password { get; set; } = string.Empty;
  public string PasswordHash { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string? Fullname { get; set; }
  public bool? Active { get; set; }
  public string? Address { get; set; }
  public bool IsLock { get; set; }
  public bool IsApprove { get; set; }
  public string? RegionName { get; set; }

  public UserEntity(string username)
  {
    Username = username;
  }

  public void SetPassword(string password, IPasswordHasher<UserEntity> passwordHasher)
  {
    if (string.IsNullOrWhiteSpace(password) || passwordHasher is null)
    {
      throw new InvalidPasswordException();
    }

    Password = password;
    PasswordHash = passwordHasher.HashPassword(this, password);
  }

  public void SetPhone(string[]? phone)
  {
    Phones = phone ?? Phones;
  }

  public bool ValidatePassword(string password, IPasswordHasher<UserEntity> passwordHasher)
  {
    return passwordHasher?.VerifyHashedPassword(this, PasswordHash, password) != PasswordVerificationResult.Failed;
  }


  public string CreateToken(ITokenProvider<UserEntity> tokenProvider)
  {
    return tokenProvider?.CreateToken(new[]
    {
      new(ClaimTypes.Name, Id.ToString()),
      new Claim("FullName", Fullname ?? "")
    }) ?? throw new FailedToCreateTokenException();
  }

  public string CreateToken(ITokenProvider<UserEntity> tokenProvider, string phone)
  {
    return tokenProvider?.CreateToken(new[]
    {
      new(ClaimTypes.Name, Id.ToString()),
      new Claim(ClaimTypes.MobilePhone, phone)
    }) ?? throw new FailedToCreateTokenException();
  }
}
