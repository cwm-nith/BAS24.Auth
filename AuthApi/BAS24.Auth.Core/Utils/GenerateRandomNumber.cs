namespace BAS24.Api.Utils;

public static class GenerateRandomNumber
{
  public static string Create(int length)
  {
    var rnm = new Random(length);
    return rnm.Next().ToString();
  }
}
