using BAS24.Api.Entities.SocialLinks;
using BAS24.Api.Entities.User;
using BAS24.Api.Enums;

namespace BAS24.Api.Entities.Stores;

public class StoreEntity
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

  public UserEntity? Owner { get; set; }
  public List<SocialUserLinkEntity>? SocialUserLinks { get; set; }
  public List<StoreMemberEntity>? StoreMembers { get; set; }

  public StoreEntity(Guid id,
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
}
