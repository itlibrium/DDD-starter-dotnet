using System.Threading.Tasks;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.ExchangeRates;
using P3Model.Annotations.Technology;

namespace MyCompany.ECommerce.Sales.Integrations.Forex;

[ExternalSoftwareSystem("Forex")]
public class ForexViaHttp : ExchangeRateProvider
{
    // The only purpose of this fake implementation is to show integration point with external software system.
    public Task<ExchangeRate> GetFor(Currency currency) => Task.FromResult(ExchangeRate.Of(currency, 1));
}