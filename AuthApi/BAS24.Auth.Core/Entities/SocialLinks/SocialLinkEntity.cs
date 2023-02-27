namespace BAS24.Api.Entities.SocialLinks;

public class SocialLinkEntity
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  
  public List<SocialUserLinkEntity>? SocialUserLinks { get; set; }

  public SocialLinkEntity(Guid id, string name, DateTime createdAt, DateTime updatedAt)
  {
    Id = id;
    Name = name;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
  }
}
