using System.ComponentModel.DataAnnotations.Schema;
using BAS24.Libs.Postgres;

namespace BAS24.Auth.Infrastructure.Postgres.Media;

[Table("medias")]
public class MediaTable : BasePostgresTable
{
  [Column("link")]
  public string Link { get; set; }

  [Column("master_id")]
  public Guid MasterId { get; set; }

  [Column("file_name")]
  public string FileName { get; set; }

  [Column("created_at")]
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  [Column("updated_at")]
  public DateTime UpdatedAt { get; set; }

  public MediaTable(string link, Guid masterId, string fileName, DateTime updatedAt)
  {
    Link = link;
    MasterId = masterId;
    FileName = fileName;
    UpdatedAt = updatedAt;
    UpdatedAt = updatedAt;
  }
}
