using System.ComponentModel.DataAnnotations.Schema;
using BAS24.Libs.Postgres;

namespace BAS24.Product.Infrastructure.Postgres.Currency;

[Table("currencies")]
public class CurrencyTable : BasePostgresTable
{
  [Column("symbol")]
  public string Symbol { get; set; }

  [Column("description")]
  public string Description { get; set; }

  [Column("active")]
  public bool Active { get; set; }

  [Column("base_currency")]
  public bool BaseCurrency { get; set; }

  [Column("local_currency")]
  public bool LocalCurrency { get; set; }

  [Column("created_at")]
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  [Column("updated_at")]
  public DateTime UpdatedAt { get; set; }

  public CurrencyTable(string symbol,
    string description,
    bool active,
    bool baseCurrency,
    bool localCurrency,
    DateTime updatedAt)
  {
    Symbol = symbol;
    Description = description;
    Active = active;
    BaseCurrency = baseCurrency;
    LocalCurrency = localCurrency;
    UpdatedAt = updatedAt;
  }
}
