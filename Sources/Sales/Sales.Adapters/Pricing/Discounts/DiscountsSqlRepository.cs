using System.Collections.Immutable;
using JetBrains.Annotations;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Products;

namespace MyCompany.ECommerce.Sales.Pricing.Discounts;

[UsedImplicitly]
public class DiscountsSqlRepository : DiscountsRepository
{
    public Task<ClientLevelDiscounts> GetFor(ClientId clientId) =>
        throw new System.NotImplementedException();

    public Task<ProductLevelDiscounts> GetFor(ImmutableArray<ProductAmount> productAmounts) =>
        throw new System.NotImplementedException();
}