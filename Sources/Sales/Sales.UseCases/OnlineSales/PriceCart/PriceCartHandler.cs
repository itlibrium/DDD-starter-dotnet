using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.Sales.SalesChannels;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Sales.OnlineSales.PriceCart
{
    [Stateless]
    [DddAppService]
    public class PriceCartHandler : CommandHandler<PriceCart, CartPriced>
    {
        private readonly CalculatePrices _calculatePrices;

        public PriceCartHandler(CalculatePrices calculatePrices) => _calculatePrices = calculatePrices;

        public async Task<CartPriced> Handle(PriceCart command)
        {
            var (clientId, currency, productAmounts) = CreateDomainModelFrom(command);
            var offer = await _calculatePrices.For(clientId, SalesChannel.OnlineSales, productAmounts, currency);
            var cartPriced = CreateEventFrom(clientId, offer);
            return cartPriced;
        }

        private static (ClientId, Currency, ImmutableArray<ProductAmount>) CreateDomainModelFrom(
            PriceCart command) => (
            ClientId.From(command.ClientId),
            command.Currency.ToDomainModel<Currency>(),
            command.CartItems
                .Select(cartItem => cartItem.ToDomainModel())
                .ToImmutableArray());

        private static CartPriced CreateEventFrom(ClientId clientId, Offer offer) => new CartPriced(
            DateTime.UtcNow,
            clientId.Value,
            offer.Currency.ToCode(),
            offer.Quotes
                .Select(quote => quote.ToDto())
                .ToImmutableArray());
    }
}