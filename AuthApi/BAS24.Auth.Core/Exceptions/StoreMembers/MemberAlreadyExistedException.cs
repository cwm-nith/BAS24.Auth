using BAS24.Libs.Exceptions;

namespace BAS24.Api.Exceptions.StoreMembers;

public class MemberAlreadyExistedException:BaseException
{
  public override string Code => "member_already_existed";
}
