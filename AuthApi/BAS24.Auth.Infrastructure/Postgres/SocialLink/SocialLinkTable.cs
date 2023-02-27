using System.ComponentModel.DataAnnotations.Schema;
using BAS24.Auth.Infrastructure.Postgres.Media;
using BAS24.Libs.Postgres;

namespace BAS24.Auth.Infrastructure.Postgres.SocialLink;

[Table("social_links")]
public class SocialLinkTable:BasePostgresTable
{
  [Column("name")]
  public string Name { get; set; }
  [Column("created_at")]
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  [Column("updated_at")]
  public DateTime UpdatedAt { get; set; }
  
  public ICollection<SocialUserLinkTable>? SocialUserLinks { get; set; }

  public SocialLinkTable(string name, DateTime updatedAt)
  {
    Name = name;
    UpdatedAt = updatedAt;
  }
}
