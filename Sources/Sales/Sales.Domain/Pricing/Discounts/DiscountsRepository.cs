using System.Collections.Immutable;
using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Products;

namespace MyCompany.Crm.Sales.Pricing.Discounts
{
    public interface DiscountsRepository
    {
        Task<ClientLevelDiscounts> GetFor(ClientId clientId);
        Task<ProductLevelDiscounts> GetFor(ImmutableArray<ProductAmount> productAmounts);
    }
}