using BAS24.Api.Entities.SocialLinks;
using BAS24.Auth.Infrastructure.Postgres.Store;

namespace BAS24.Auth.Infrastructure.Postgres.SocialLink;

public static class Extensions
{
  public static SocialUserLinkEntity AsEntity(this SocialUserLinkTable s) => new(
    id: s.Id,
    socialLinkId: s.SocialLinkId,
    storeId: s.StoreId,
    storeOwnerId: s.StoreOwnerId,
    link: s.Link,
    updatedAt: s.UpdatedAt
  )
  {
    SocialLink = s.SocialLink?.AsEntity(),
    Store = s.Store?.AsEntity(),
    CreatedAt = s.CreatedAt,
  };

  public static SocialUserLinkTable AsTable(this SocialUserLinkEntity s) => new(
    socialLinkId: s.SocialLinkId,
    storeId: s.StoreId,
    storeOwnerId: s.StoreOwnerId,
    link: s.Link,
    updatedAt: s.UpdatedAt
  )
  {
    SocialLink = s.SocialLink?.AsTable(),
    CreatedAt = s.CreatedAt,
    Id = s.Id,
    Store = s.Store?.AsTable(),
  };

  public static SocialLinkEntity AsEntity(this SocialLinkTable s) => new(id: s.Id,
    name: s.Name,
    createdAt: s.CreatedAt,
    updatedAt: s.UpdatedAt)
  {
    SocialUserLinks = s.SocialUserLinks?.Select(i => i.AsEntity()).ToList(),
  };

  public static SocialLinkTable AsTable(this SocialLinkEntity s) =>
    new(name: s.Name, updatedAt: s.UpdatedAt)
    {
      CreatedAt = s.CreatedAt,
      Id = s.Id,
      SocialUserLinks = s.SocialUserLinks?.Select(i => i.AsTable()).ToList()
    };
}
