using System.ComponentModel.DataAnnotations.Schema;
using BAS24.Auth.Infrastructure.Postgres.Store;
using BAS24.Libs.Postgres;

namespace BAS24.Auth.Infrastructure.Postgres.SocialLink;

[Table("social_user_links")]
public class SocialUserLinkTable:BasePostgresTable
{
  [Column("social_link_id")]
  public Guid SocialLinkId { get; set; }
  [Column("store_id")]
  public Guid StoreId { get; set; }
  [Column("store_owner_id")]
  public Guid StoreOwnerId { get; set; }
  [Column("link")]
  public string Link { get; set; }
  
  [Column("created_at")]
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  [Column("updated_at")]
  public DateTime UpdatedAt { get; set; }
  
  public SocialLinkTable? SocialLink { get; set; }
  public StoreTable? Store { get; set; }
}

