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

namespace MyCompany.Crm.Sales.OnlineSales.PriceCart
{
    public class PriceCartHandler
    {
        private readonly CalculatePrices _calculatePrices;

        public PriceCartHandler(CalculatePrices calculatePrices) => _calculatePrices = calculatePrices;

        public async Task<CartPriced> Handle(PriceCartCommand command)
        {
            var (clientId, currency, productAmounts) = CreateDomainModelFrom(command);
            var offer = await _calculatePrices.For(clientId, SalesChannel.OnlineSales, productAmounts, currency);
            var cartPriced = CreateEventFrom(clientId, offer);
            return cartPriced;
        }

        private static (ClientId, Currency, ImmutableArray<ProductAmount>) CreateDomainModelFrom(
            PriceCartCommand command) => (
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