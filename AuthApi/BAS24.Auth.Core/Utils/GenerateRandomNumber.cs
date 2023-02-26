namespace BAS24.Api.Utils;

public static class GenerateRandomNumber
{
  public static string Create(int length)
  {
    var finalCode = "";
    for (var num = 0; num < length; num++)
    {
      var rnm = new Random();
      var code = rnm.Next(10).ToString();
      finalCode += code;
    }

    return finalCode;
  }

}
