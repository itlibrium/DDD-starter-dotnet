using System.Collections.Immutable;
using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Products;

namespace MyCompany.Crm.Sales.Pricing.PriceLists
{
    public interface PriceListRepository
    {
        Task<Money> GetBasePriceFor(ClientId clientId, ProductAmount productAmount);
        Task<BasePrices> GetBasePricesFor(ClientId clientId, ImmutableArray<ProductAmount> productAmounts);
    }
}