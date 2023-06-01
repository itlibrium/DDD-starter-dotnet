using System.Threading.Tasks;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.TechnicalStuff.Metadata;

namespace MyCompany.ECommerce.Sales.ExchangeRates
{
    [ExternalService]
    internal class FakeExchangeRateProvider : ExchangeRateProvider
    {
        public Task<ExchangeRate> GetFor(Currency currency) => Task.FromResult(ExchangeRate.Of(currency, 1));
    }
}