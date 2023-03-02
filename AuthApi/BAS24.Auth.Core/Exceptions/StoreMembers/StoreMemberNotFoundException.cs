using BAS24.Libs.Exceptions;

namespace BAS24.Api.Exceptions.StoreMembers;

public class StoreMemberNotFoundException:BaseException
{
  public override string Code => "store_member_not_found";
}
