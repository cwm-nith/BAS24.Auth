using BAS24.Api.Dtos.Stores;
using BAS24.Api.Entities.SocialLinks;

namespace BAS24.Api.Dtos.SocialLinks;

public class SocialUserLinkDto
{
  public Guid Id { get; set; }
  public Guid SocialLinkId { get; set; }
  public Guid StoreId { get; set; }
  public Guid StoreOwnerId { get; set; }
  public string Link { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  public SocialLinkDto? SocialLink { get; set; }
  public StoreDto? Store { get; set; }

  public SocialUserLinkDto(Guid id,
    Guid socialLinkId,
    Guid storeId,
    Guid storeOwnerId,
    string link,
    DateTime updatedAt,
    DateTime createdAt)
  {
    Id = id;
    SocialLinkId = socialLinkId;
    StoreId = storeId;
    StoreOwnerId = storeOwnerId;
    Link = link;
    UpdatedAt = updatedAt;
    CreatedAt = createdAt;
  }

  public static SocialUserLinkDto FromEntity(SocialUserLinkEntity e) => new SocialUserLinkDto(
    id: e.Id,
    socialLinkId: e.SocialLinkId,
    storeId: e.StoreId,
    storeOwnerId: e.StoreOwnerId,
    link: e.Link,
    updatedAt: e.UpdatedAt,
    createdAt: e.CreatedAt)
  {
    SocialLink = e.SocialLink != null ? SocialLinkDto.FromEntity(e.SocialLink) : null,
    Store = e.Store != null ? StoreDto.FromEntity(e.Store) : null,
  };
}
