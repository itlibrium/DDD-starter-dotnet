using System.Threading.Tasks;
using MyCompany.ECommerce.Sales.Commons;

namespace MyCompany.ECommerce.Sales.ExchangeRates
{
    public interface ExchangeRateProvider
    {
        Task<ExchangeRate> GetFor(Currency currency);
    }
}