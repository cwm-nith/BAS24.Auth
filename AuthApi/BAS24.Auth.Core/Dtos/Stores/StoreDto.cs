using BAS24.Api.Dtos.SocialLinks;
using BAS24.Api.Dtos.Users;
using BAS24.Api.Entities.SocialLinks;
using BAS24.Api.Entities.Stores;
using BAS24.Api.Entities.User;
using BAS24.Api.Enums;

namespace BAS24.Api.Dtos.Stores;

public class StoreDto
{
  public Guid Id { get; set; }
  public Guid OwnerId { get; set; }

  public string Name { get; set; }

  public string? Description { get; set; }

  public string Address { get; set; }

  public string[] Phones { get; set; }

  public string[] Emails { get; set; }

  public string[] Tags { get; set; }

  public string[] KeyWords { get; set; }

  public Guid[] CategoryIds { get; set; }

  public Rating PriceRating { get; set; } = Rating.None;

  public Rating StoreRating { get; set; }

  public DateTime StartWorkingTime { get; set; }

  public DateTime EndWorkingTime { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  public DateTime UpdatedAt { get; set; }

  public UserDto? Owner { get; set; }
  public List<SocialUserLinkDto>? SocialUserLinks { get; set; }
  public List<StoreMemberEntity>? StoreMembers { get; set; }

  public StoreDto(Guid id,
    Guid ownerId,
    string name,
    string? description,
    string address,
    string[] phones,
    string[] emails,
    string[] tags,
    string[] keyWords,
    Guid[] categoryIds,
    Rating priceRating,
    Rating storeRating,
    DateTime startWorkingTime,
    DateTime endWorkingTime,
    DateTime updatedAt)
  {
    Id = id;
    OwnerId = ownerId;
    Name = name;
    Description = description;
    Address = address;
    Phones = phones;
    Emails = emails;
    Tags = tags;
    KeyWords = keyWords;
    CategoryIds = categoryIds;
    PriceRating = priceRating;
    StoreRating = storeRating;
    StartWorkingTime = startWorkingTime;
    EndWorkingTime = endWorkingTime;
    UpdatedAt = updatedAt;
  }
  
  public static StoreDto FromEntity(StoreEntity e)
  {
    return new StoreDto(id: e.Id,
      ownerId: e.OwnerId,
      name: e.Name,
      description: e.Description,
      address: e.Address,
      phones: e.Phones,
      emails: e.Emails,
      tags: e.Tags,
      keyWords: e.KeyWords,
      categoryIds: e.CategoryIds,
      priceRating: e.PriceRating,
      storeRating: e.StoreRating,
      startWorkingTime: e.StartWorkingTime,
      endWorkingTime: e.EndWorkingTime,
      updatedAt: e.UpdatedAt)
    {
      CreatedAt = e.CreatedAt,
      Owner = e.Owner != null ? UserDto.FromEntity(e.Owner) : null,
      SocialUserLinks = e.SocialUserLinks?.Select(SocialUserLinkDto.FromEntity).ToList(),
    };
  }
}
