using System.Collections.Immutable;
using JetBrains.Annotations;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Pricing.PriceLists;
using MyCompany.ECommerce.Sales.Products;

namespace MyCompany.ECommerce.Sales.Pricing;

[UsedImplicitly]
public class PriceListSqlRepository : PriceListRepository
{
    public Task<Money> GetBasePriceFor(ClientId clientId, ProductAmount productAmount) => 
        throw new System.NotImplementedException();

    public Task<BasePrices> GetBasePricesFor(ClientId clientId, ImmutableArray<ProductAmount> productAmounts) => 
        throw new System.NotImplementedException();
}