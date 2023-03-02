using BAS24.Libs.Exceptions;

namespace BAS24.Api.Exceptions.Stores;

public class StoreCodeVerifyNotValidException:BaseException
{
  public override string Code => "store_code_verify_not_valid";
}
