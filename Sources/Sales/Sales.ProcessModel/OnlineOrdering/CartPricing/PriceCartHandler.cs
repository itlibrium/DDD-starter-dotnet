using System.Collections.Immutable;
using JetBrains.Annotations;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Pricing;
using MyCompany.ECommerce.Sales.Products;
using MyCompany.ECommerce.Sales.SalesChannels;
using MyCompany.ECommerce.TechnicalStuff;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain;
using P3Model.Annotations.People;

namespace MyCompany.ECommerce.Sales.OnlineOrdering.CartPricing;

[UsedImplicitly]
public class PriceCartHandler(CalculatePrices calculatePrices) : CommandHandler<PriceCart, CartPriced>
{
    [UseCase(nameof(PriceCart), Process = OnlineOrderingProcess.Name)]
    [Actor(Actors.RetailClient)]
    public async Task<CartPriced> Handle(PriceCart command)
    {
            var (clientId, currency, productAmounts) = CreateDomainModelFrom(command);
            var offer = await calculatePrices.For(clientId, SalesChannel.OnlineSale, productAmounts, currency);
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

    private static CartPriced CreateEventFrom(ClientId clientId, Offer offer) => new(
        DateTime.UtcNow,
        clientId.Value,
        offer.Currency.ToCode(),
        offer.Quotes
            .Select(quote => quote.ToDto())
            .ToImmutableArray());
}