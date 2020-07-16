using System.Collections.Immutable;
using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Pricing.Discounts
{
    [DddRepository]
    public interface DiscountsRepository
    {
        Task<ClientLevelDiscounts> GetFor(ClientId clientId);
        Task<ProductLevelDiscounts> GetFor(ImmutableArray<ProductAmount> productAmounts);
    }
}