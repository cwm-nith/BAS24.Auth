namespace BAS24.Api.Constants;

public static class StoreMemberPermissions
{
  public static int General => 2;
  public static int AdsManagement => 4;
  public static int VoidOrCancelInvoice => 8;
  public static int StockController => 16;
  public static int Cashier => 32;
  public static int Administration
  {
    get
    {
      return typeof(StoreMemberPermissions)
        .GetProperties()
        .Where(prop => prop.Name != "Administration")
        .Sum(prop => (int)(prop.GetValue(null) ?? 0));
    }
  }
}
