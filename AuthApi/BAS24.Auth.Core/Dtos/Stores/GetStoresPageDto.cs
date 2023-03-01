using BAS24.Libs.CQRS.Queries;

namespace BAS24.Api.Dtos.Stores;

public class GetStoresPageDto:PagedQuery
{
  public string? OwnerId { get; set; }
}
