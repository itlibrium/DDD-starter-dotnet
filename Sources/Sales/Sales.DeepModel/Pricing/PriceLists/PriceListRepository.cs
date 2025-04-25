using System.Collections.Immutable;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Products;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Pricing.PriceLists;

[DddRepository]
public interface PriceListRepository
{
    Task<Money> GetBasePriceFor(ClientId clientId, ProductAmount productAmount);
    Task<BasePrices> GetBasePricesFor(ClientId clientId, ImmutableArray<ProductAmount> productAmounts);
}