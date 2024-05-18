using System.Collections.Immutable;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.ExchangeRates;
using MyCompany.ECommerce.Sales.Pricing.PriceLists;
using MyCompany.ECommerce.Sales.Products;
using MyCompany.ECommerce.Sales.SalesChannels;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Pricing;

[DddDomainService]
public class CalculatePrices(
    PriceListRepository priceLists,
    OfferModifiers offerModifiers,
    ExchangeRateProvider exchangeRates)
{
    public async Task<Quote> For(ClientId clientId, SalesChannel salesChannel, ProductAmount productAmount,
        Currency currency) =>
        (await For(clientId, salesChannel, ImmutableArray.Create(productAmount), currency))
        .Quotes.Single();

    public Task<Offer> For(ClientId clientId, SalesChannel salesChannel,
        IEnumerable<ProductAmount> productAmounts, Currency currency) =>
        For(clientId, salesChannel, productAmounts.ToImmutableArray(), currency);
        
    public async Task<Offer> For(ClientId clientId, SalesChannel salesChannel,
        ImmutableArray<ProductAmount> productAmounts, Currency currency)
    {
        var offerRequest = OfferRequest.For(clientId, salesChannel, productAmounts);
        var (basePrices, offerModifier, exchangeRate) = await (
            priceLists.GetBasePricesFor(clientId, productAmounts),
            offerModifiers.ChooseFor(offerRequest),
            exchangeRates.GetFor(currency));
        return Offer.WithBasePrices(productAmounts, basePrices)
            .Apply(offerModifier)
            .Apply(exchangeRate);
    }
}