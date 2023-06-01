using System.Collections.Immutable;
using System.Threading.Tasks;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Products;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.ECommerce.Sales.Pricing.PriceLists
{
    [DddRepository]
    public interface PriceListRepository
    {
        Task<Money> GetBasePriceFor(ClientId clientId, ProductAmount productAmount);
        Task<BasePrices> GetBasePricesFor(ClientId clientId, ImmutableArray<ProductAmount> productAmounts);
    }
}