using MyCompany.ECommerce.Sales.Commons;
using P3Model.Annotations.Domain;

namespace MyCompany.ECommerce.Sales.ExchangeRates;

[ExternalSystemIntegration("Forex")]
public interface ExchangeRateProvider
{
    Task<ExchangeRate> GetFor(Currency currency);
}