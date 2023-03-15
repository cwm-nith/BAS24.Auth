namespace BAS24.Product.Core.Utils;

public static class GuidHelper
{
  public static string NewId
    => Guid.NewGuid().ToString("N");
}
