using BAS24.Libs.CQRS.Commands;

namespace BAS24.Auth.Application.Commands.Stores;

public class UpdateStoreCommand : ICommand
{
  public Guid Id { get; set; }
  public Guid OwnerId { get; set; }
  public string Name { get; set; }
  public string? Description { get; set; }
  public string Address { get; set; }
  public string[] Phones { get; set; }
  public string[] Emails { get; set; }
  public string[] Tags { get; set; }
  public string[] KeyWords { get; set; }
  
  public UpdateStoreCommand(Guid id,
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
    OwnerId = ownerId;
    Name = name;
    Description = description;
    Address = address;
    Phones = phones;
    Emails = emails;
    Tags = tags;
    KeyWords = keyWords;
  }
}
