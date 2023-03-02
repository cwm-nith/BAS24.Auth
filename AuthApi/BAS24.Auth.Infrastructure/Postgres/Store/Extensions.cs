using BAS24.Api.Entities.Stores;
using BAS24.Auth.Infrastructure.Postgres.SocialLink;
using BAS24.Auth.Infrastructure.Postgres.User;

namespace BAS24.Auth.Infrastructure.Postgres.Store;

public static class Extensions
{
  public static StoreMemberTable AsTable(this StoreMemberEntity s) => new(
    storeId: s.StoreId,
    memberId: s.MemberId,
    updatedAt: s.UpdatedAt,
    permission: s.Permission
  )
  {
    Id = s.Id,
    CreatedAt = s.CreatedAt,
  };

  public static StoreMemberEntity AsEntity(this StoreMemberTable s) => new(
    id: s.Id,
    storeId: s.StoreId,
    memberId: s.MemberId,
    permission: s.Permission,
    createdAt: s.CreatedAt,
    updatedAt: s.UpdatedAt
  );

  public static StoreTable AsTable(this StoreEntity e) => new(
    ownerId: e.OwnerId,
    name: e.Name,
    address: e.Address,
    phones: e.Phones,
    emails: e.Emails,
    tags: e.Tags,
    keyWords: e.KeyWords,
    categoryIds: e.CategoryIds,
    storeRating: e.StoreRating,
    startWorkingTime: e.StartWorkingTime,
    endWorkingTime: e.EndWorkingTime,
    active: e.Active,
    updatedAt: e.UpdatedAt
  )
  {
    Id = e.Id,
    Code = e.Code,
    Description = e.Description,
    Owner = e.Owner?.AsTable(),
    StoreMembers = e.StoreMembers?.Select(i => i.AsTable()).ToList(),
    SocialUserLinks = e.SocialUserLinks?.Select(i => i.AsTable()).ToList()
  };

  public static StoreEntity AsEntity(this StoreTable s) => new(
    id: s.Id,
    ownerId: s.OwnerId,
    name: s.Name,
    description: s.Description,
    address: s.Address,
    phones: s.Phones,
    emails: s.Emails,
    tags: s.Tags,
    keyWords: s.KeyWords,
    categoryIds: s.CategoryIds,
    priceRating: s.PriceRating,
    storeRating: s.StoreRating,
    startWorkingTime: s.StartWorkingTime,
    endWorkingTime: s.EndWorkingTime,
    active: s.Active,
    updatedAt: s.UpdatedAt
  )
  {
    Code = s.Code,
    Owner = s.Owner?.AsEntity(),
    StoreMembers = s.StoreMembers?.Select(i => i.AsEntity()).ToList(),
    SocialUserLinks = s.SocialUserLinks?.Select(i=> i.AsEntity()).ToList()
  };
}
