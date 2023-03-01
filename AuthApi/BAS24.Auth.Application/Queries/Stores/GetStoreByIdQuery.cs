using BAS24.Api.Dtos.Stores;
using BAS24.Libs.CQRS.Queries;

namespace BAS24.Auth.Application.Queries.Stores;

public class GetStoreByIdQuery:IQuery<StoreDto>
{
  public Guid Id { get; set; }

  public GetStoreByIdQuery(Guid id)
  {
    Id = id;
  }
}
