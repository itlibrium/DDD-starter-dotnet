using System.Collections.Immutable;
using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Pricing.PriceLists;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Pricing
{
    [DddRepository]
    public class PriceListSqlRepository : PriceListRepository
    {
        public Task<Money> GetBasePriceFor(ClientId clientId, ProductAmount productAmount) => 
            throw new System.NotImplementedException();

        public Task<BasePrices> GetBasePricesFor(ClientId clientId, ImmutableArray<ProductAmount> productAmounts) => 
            throw new System.NotImplementedException();
    }
}