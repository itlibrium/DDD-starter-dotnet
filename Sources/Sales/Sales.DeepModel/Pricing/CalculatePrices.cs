using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.ExchangeRates;
using MyCompany.Crm.Sales.Pricing.PriceLists;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.Sales.SalesChannels;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;
using TaskTupleAwaiter;

namespace MyCompany.Crm.Sales.Pricing
{
    [DddDomainService]
    public class CalculatePrices
    {
        private readonly PriceListRepository _priceLists;
        private readonly OfferModifiers _offerModifiers;
        private readonly ExchangeRateProvider _exchangeRates;

        public CalculatePrices(PriceListRepository priceLists, OfferModifiers offerModifiers,
            ExchangeRateProvider exchangeRates)
        {
            _priceLists = priceLists;
            _offerModifiers = offerModifiers;
            _exchangeRates = exchangeRates;
        }

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
                _priceLists.GetBasePricesFor(clientId, productAmounts),
                _offerModifiers.ChooseFor(offerRequest),
                _exchangeRates.GetFor(currency));
            return Offer.WithBasePrices(productAmounts, basePrices)
                .Apply(offerModifier)
                .Apply(exchangeRate);
        }
    }
}