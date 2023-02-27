using BAS24.Api.Entities.Stores;

namespace BAS24.Api.Entities.SocialLinks;

public class SocialUserLinkEntity
{
  public Guid Id { get; set; }
  public Guid SocialLinkId { get; set; }
  public Guid StoreId { get; set; }
  public Guid StoreOwnerId { get; set; }
  public string Link { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; }

  public SocialLinkEntity? SocialLink { get; set; }
  public StoreEntity? Store { get; set; }

  public SocialUserLinkEntity(Guid id,
    Guid socialLinkId,
    Guid storeId,
    Guid storeOwnerId,
    string link,
    DateTime updatedAt)
  {
    Id = id;
    SocialLinkId = socialLinkId;
    StoreId = storeId;
    StoreOwnerId = storeOwnerId;
    Link = link;
    UpdatedAt = updatedAt;
  }
}
