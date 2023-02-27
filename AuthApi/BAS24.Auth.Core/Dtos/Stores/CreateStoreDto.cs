namespace BAS24.Api.Dtos.Stores;

public class CreateStoreDto
{
  public string Name { get; set; }
  public string? Description { get; set; }
  public string Address { get; set; }
  public string[] Phones { get; set; }
  public string[] Emails { get; set; }
  public string[] Tags { get; set; }
  public string[] KeyWords { get; set; }
  public Guid[] CategoryIds { get; set; }
  public DateTime StartWorkingTime { get; set; }
  public DateTime EndWorkingTime { get; set; }

  public CreateStoreDto(string name,
    string? description,
    string address,
    string[] phones,
    string[] emails,
    string[] tags,
    string[] keyWords,
    Guid[] categoryIds,
    DateTime startWorkingTime,
    DateTime endWorkingTime)
  {
    Name = name;
    Description = description;
    Address = address;
    Phones = phones;
    Emails = emails;
    Tags = tags;
    KeyWords = keyWords;
    CategoryIds = categoryIds;
    StartWorkingTime = startWorkingTime;
    EndWorkingTime = endWorkingTime;
  }
}
