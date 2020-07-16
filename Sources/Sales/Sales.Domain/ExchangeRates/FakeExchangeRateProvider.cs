using System.Threading.Tasks;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.TechnicalStuff.Metadata;

namespace MyCompany.Crm.Sales.ExchangeRates
{
    [Stateless]
    internal class FakeExchangeRateProvider : ExchangeRateProvider
    {
        public Task<ExchangeRate> GetFor(Currency currency) => Task.FromResult(ExchangeRate.Of(currency, 1));
    }
}