using BAS24.Api.Dtos.Stores;
using BAS24.Libs.CQRS.Queries;

namespace BAS24.Auth.Application.Queries.Stores;

public class GetStoresPageQuery:IQuery<PagedResult<StoreDto>>
{
  public int Page { get; set; }
  public int Results { get; set; }
  public string? OwnerId { get; set; }
  public bool Active { get; set; }
}
