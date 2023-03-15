using BAS24.Product.Core.Dtos.Currency;
using BAS24.Product.Core.Entities.Currency;

namespace BAS24.Product.Infrastructure.Postgres.Currency;

public static class Extensions
{
  public static CurrencyEntity AsEntity(this CurrencyTable c) => new(
    id: c.Id,
    storeOwnerId: c.StoreOwnerId,
    storeId: c.StoreId,
    symbol: c.Symbol,
    description: c.Description,
    active: c.Active,
    baseCurrency: c.BaseCurrency,
    localCurrency: c.LocalCurrency,
    createdAt: c.CreatedAt,
    updatedAt: c.UpdatedAt
  );

  public static CurrencyTable AsTable(this CurrencyEntity c) => new(
    storeOwnerId: c.StoreOwnerId,
    storeId: c.StoreId,
    symbol: c.Symbol,
    description: c.Description,
    active: c.Active,
    baseCurrency: c.BaseCurrency,
    localCurrency: c.LocalCurrency,
    updatedAt: c.UpdatedAt
  ) { CreatedAt = c.CreatedAt, Id = c.Id };

  public static CurrencyDto AsDto(this CurrencyEntity c) => new(
    id: c.Id,
    storeOwnerId:c.StoreOwnerId,
    storeId: c.StoreId,
    symbol: c.Symbol,
    description: c.Description,
    active: c.Active,
    baseCurrency: c.BaseCurrency,
    localCurrency: c.LocalCurrency,
    createdAt: c.CreatedAt,
    updatedAt: c.UpdatedAt
  );
}
