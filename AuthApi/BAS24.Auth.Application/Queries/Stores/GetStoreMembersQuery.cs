using BAS24.Api.Dtos.Stores;
using BAS24.Libs.CQRS.Queries;

namespace BAS24.Auth.Application.Queries.Stores;

public class GetStoreMembersQuery:PagedQuery, IQuery<PagedResult<StoreMemberDto>>
{
  public Guid StoreId { get; set; }
  public StoreMemberFilterEnum Filter { get; set; } = StoreMemberFilterEnum.All;
}
