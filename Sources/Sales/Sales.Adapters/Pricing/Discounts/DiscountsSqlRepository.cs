using System.Collections.Immutable;
using System.Threading.Tasks;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Products;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.ECommerce.Sales.Pricing.Discounts
{
    [DddRepository]
    public class DiscountsSqlRepository : DiscountsRepository
    {
        public Task<ClientLevelDiscounts> GetFor(ClientId clientId) =>
            throw new System.NotImplementedException();

        public Task<ProductLevelDiscounts> GetFor(ImmutableArray<ProductAmount> productAmounts) =>
            throw new System.NotImplementedException();
    }
}