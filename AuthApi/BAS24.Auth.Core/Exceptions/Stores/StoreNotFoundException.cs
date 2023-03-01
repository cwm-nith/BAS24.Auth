using BAS24.Libs.Exceptions;

namespace BAS24.Api.Exceptions.Stores;

public class StoreNotFoundException:BaseException
{
  public override string Code => "store_not_found";
}
