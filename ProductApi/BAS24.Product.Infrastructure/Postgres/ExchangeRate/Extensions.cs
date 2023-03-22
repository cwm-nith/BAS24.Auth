using BAS24.Product.Core.Dtos.ExchangeRate;
using BAS24.Product.Core.Entities.ExchangeRate;

namespace BAS24.Product.Infrastructure.Postgres.ExchangeRate;

public static class Extensions
{
  public static ExchangeRateTable AsTable(this ExchangeRateEntity e) => new(
    currencyId: e.CurrencyId,
    rate: e.Rate,
    setRate: e.SetRate,
    localSetRate: e.LocalSetRate,
    baseSetRate: e.BaseSetRate,
    updatedAt: e.UpdatedAt
  )
  {
    Id = e.Id,
    CreatedAt = e.CreatedAt
  };

  public static ExchangeRateEntity AsEntity(this ExchangeRateTable e) => new(
    id: e.Id,
    currencyId: e.CurrencyId,
    rate: e.Rate,
    setRate: e.SetRate,
    localSetRate: e.LocalSetRate,
    baseSetRate: e.BaseSetRate,
    createdAt: e.CreatedAt,
    updatedAt: e.UpdatedAt
  );

  public static ExchangeRateDto AsDto(this ExchangeRateEntity e) => new(
    id: e.Id,
    currencyId: e.CurrencyId,
    rate: e.Rate,
    setRate: e.SetRate,
    localSetRate: e.LocalSetRate,
    baseSetRate: e.BaseSetRate,
    createdAt: e.CreatedAt,
    updatedAt: e.UpdatedAt
  );
}
