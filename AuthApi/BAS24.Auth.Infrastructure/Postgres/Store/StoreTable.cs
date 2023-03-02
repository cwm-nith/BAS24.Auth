using System.ComponentModel.DataAnnotations.Schema;
using BAS24.Api.Enums;
using BAS24.Auth.Infrastructure.Postgres.Media;
using BAS24.Auth.Infrastructure.Postgres.SocialLink;
using BAS24.Auth.Infrastructure.Postgres.User;
using BAS24.Libs.Postgres;

namespace BAS24.Auth.Infrastructure.Postgres.Store;

[Table("stores")]
public class StoreTable : BasePostgresTable
{
  [Column("owner_id")]
  public Guid OwnerId { get; set; }

  [Column("name")]
  public string Name { get; set; }

  [Column("description")]
  public string? Description { get; set; }

  [Column("address")]
  public string Address { get; set; }

  [Column("phones")]
  public string[] Phones { get; set; }

  [Column("emails")]
  public string[] Emails { get; set; }

  [Column("tags")]
  public string[] Tags { get; set; }

  [Column("key_words")]
  public string[] KeyWords { get; set; }

  [Column("categoryIds")]
  public Guid[] CategoryIds { get; set; }

  [Column("price_rating")]
  public Rating PriceRating { get; set; } = Rating.None;

  [Column("store_rating")]
  public Rating StoreRating { get; set; }

  [Column("start_working_time")]
  public DateTime StartWorkingTime { get; set; }

  [Column("end_working_time")]
  public DateTime EndWorkingTime { get; set; }
  
  [Column("active")]
  public bool Active { get; set; }
  
  [Column("code")]
  public string? Code { get; set; }
  [Column("created_at")]
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  [Column("updated_at")]
  public DateTime UpdatedAt { get; set; }

  public UserTable? Owner { get; set; }
  public ICollection<SocialUserLinkTable>? SocialUserLinks { get; set; }
  public ICollection<StoreMemberTable>? StoreMembers { get; set; }
  public ICollection<MediaTable>? Medias { get; set; }
  
  public StoreTable(Guid ownerId,
    string name,
    string address,
    string[] phones,
    string[] emails,
    string[] tags,
    string[] keyWords,
    Guid[] categoryIds,
    Rating storeRating,
    DateTime startWorkingTime,
    DateTime endWorkingTime,
    bool active,
    DateTime updatedAt)
  {
    OwnerId = ownerId;
    Name = name;
    Address = address;
    Phones = phones;
    Emails = emails;
    Tags = tags;
    KeyWords = keyWords;
    CategoryIds = categoryIds;
    StoreRating = storeRating;
    StartWorkingTime = startWorkingTime;
    EndWorkingTime = endWorkingTime;
    Active = active;
    UpdatedAt = updatedAt;
  }
}
