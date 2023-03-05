using BAS24.Libs.CQRS.Queries;

namespace BAS24.Api.Dtos.Stores;

public class GetStoreMembersDto:PagedQuery
{
  public Guid StoreId { get; set; }
  public StoreMemberFilterEnum Filter { get; set; } = StoreMemberFilterEnum.All; // all | accepted | notAccepted
}

public enum StoreMemberFilterEnum
{
  All = 1,
  Accepted = 2,
  NotAccepted = 3
} 