using BAS24.Api.Entities.SocialLinks;

namespace BAS24.Api.Dtos.SocialLinks;

public class SocialLinkDto
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  public List<SocialUserLinkDto>? SocialUserLinks { get; set; }

  public SocialLinkDto(Guid id, string name, DateTime createdAt, DateTime updatedAt)
  {
    Id = id;
    Name = name;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
  }

  public static SocialLinkDto FromEntity(SocialLinkEntity e)
    => new SocialLinkDto(id: e.Id, name: e.Name, createdAt: e.CreatedAt, updatedAt: e.UpdatedAt)
    {
      SocialUserLinks = e.SocialUserLinks?.Select(SocialUserLinkDto.FromEntity).ToList(),
    };
}
