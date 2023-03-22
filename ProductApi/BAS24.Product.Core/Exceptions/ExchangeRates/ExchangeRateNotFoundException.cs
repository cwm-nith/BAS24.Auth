using BAS24.Libs.Exceptions;

namespace BAS24.Product.Core.Exceptions.ExchangeRates;

public class ExchangeRateNotFoundException:BaseException
{
  public override string Code => "exchange_rate_not_found";
}
