using System.ComponentModel.DataAnnotations.Schema;
using BAS24.Libs.Postgres;

namespace BAS24.Product.Infrastructure.Postgres.ExchangeRate;

[Table("exchange_rate")]
public class ExchangeRateTable : BasePostgresTable
{
  [Column("currency_id")]
  public Guid CurrencyId { get; set; }

  [Column("rate")]
  public decimal Rate { get; set; }

  [Column("set_rate")]
  public decimal SetRate { get; set; }

  [Column("local_set_rate")]
  public decimal LocalSetRate { get; set; }

  [Column("base_set_rate")]
  public decimal BaseSetRate { get; set; }

  [Column("created_at")]
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  [Column("updated_at")]
  public DateTime UpdatedAt { get; set; }

  public ExchangeRateTable(Guid currencyId,
    decimal rate,
    decimal setRate,
    decimal localSetRate,
    decimal baseSetRate,
    DateTime updatedAt)
  {
    CurrencyId = currencyId;
    Rate = rate;
    SetRate = setRate;
    LocalSetRate = localSetRate;
    BaseSetRate = baseSetRate;
    UpdatedAt = updatedAt;
  }
}
