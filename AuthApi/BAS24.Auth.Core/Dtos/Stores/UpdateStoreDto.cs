using BAS24.Api.Enums;

namespace BAS24.Api.Dtos.Stores;

public class UpdateStoreDto
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string? Description { get; set; }
  public string Address { get; set; }
  public string[] Phones { get; set; }
  public string[] Emails { get; set; }
  public string[] Tags { get; set; }
  public string[] KeyWords { get; set; }

  public UpdateStoreDto(Guid id,
    Guid ownerId,
    string name,
    string? description,
    string address,
    string[] phones,
    string[] emails,
    string[] tags,
    string[] keyWords)
  {
    Id = id;
    Name = name;
    Description = description;
    Address = address;
    Phones = phones;
    Emails = emails;
    Tags = tags;
    KeyWords = keyWords;
  }
}
