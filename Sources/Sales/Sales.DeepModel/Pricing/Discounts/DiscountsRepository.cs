using System.Collections.Immutable;
using System.Threading.Tasks;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Products;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Pricing.Discounts
{
    [DddRepository]
    public interface DiscountsRepository
    {
        Task<ClientLevelDiscounts> GetFor(ClientId clientId);
        Task<ProductLevelDiscounts> GetFor(ImmutableArray<ProductAmount> productAmounts);
    }
}