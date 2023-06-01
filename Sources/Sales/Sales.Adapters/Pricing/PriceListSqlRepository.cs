using System.Collections.Immutable;
using System.Threading.Tasks;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Pricing.PriceLists;
using MyCompany.ECommerce.Sales.Products;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.ECommerce.Sales.Pricing
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