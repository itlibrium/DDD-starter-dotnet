using System.Threading.Tasks;
using MyCompany.Crm.Sales.Commons;

namespace MyCompany.Crm.Sales.ExchangeRates
{
    public interface ExchangeRateProvider
    {
        Task<ExchangeRate> GetFor(Currency currency);
    }
}