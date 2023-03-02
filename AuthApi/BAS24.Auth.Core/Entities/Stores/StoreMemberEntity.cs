using BAS24.Api.Constants;
using BAS24.Api.Entities.User;
using BAS24.Api.Enums;

namespace BAS24.Api.Entities.Stores;

public class StoreMemberEntity
{
  public Guid Id { get; set; }
  public Guid StoreId { get; set; }
  public Guid MemberId { get; set; }
  public int Permission { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  public StoreMemberEntity(Guid id,
    Guid storeId,
    Guid memberId,
    int permission,
    DateTime createdAt,
    DateTime updatedAt)
  {
    Id = id;
    StoreId = storeId;
    MemberId = memberId;
    Permission = permission;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
  }

  public bool IsAdmin => (Permission & StoreMemberPermissions.Administration) > 0;
  public bool IsCashier => (Permission & StoreMemberPermissions.Cashier) > 0;
  public bool IsGeneral => (Permission & StoreMemberPermissions.General) > 0;
  public bool IsAdsManagement => (Permission & StoreMemberPermissions.AdsManagement) > 0;
  public bool IsVoidOrCancelInvoice => (Permission & StoreMemberPermissions.VoidOrCancelInvoice) > 0;
  public bool IsStockController => (Permission & StoreMemberPermissions.StockController) > 0;
}
