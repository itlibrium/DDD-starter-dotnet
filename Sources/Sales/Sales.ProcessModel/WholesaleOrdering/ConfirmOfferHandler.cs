using System.Collections.Immutable;
using JetBrains.Annotations;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Orders;
using MyCompany.ECommerce.Sales.Orders.PriceChanges;
using MyCompany.ECommerce.Sales.Pricing;
using MyCompany.ECommerce.Sales.SalesChannels;
using MyCompany.ECommerce.Sales.Time;
using MyCompany.ECommerce.TechnicalStuff;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.People;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering;

[UsedImplicitly]
public class ConfirmOfferHandler(
    Order.Repository orders,
    SalesCrudOperations crudOperations,
    CalculatePrices calculatePrices,
    PriceChangesPolicies priceChangesPolicies,
    OrderEventsOutbox eventsOutbox,
    Clock clock)
    : CommandHandler<ConfirmOffer, OfferConfirmed>
{
    private readonly TimeSpan _offerExpirationTime = TimeSpan.FromHours(24);

    [Actor(Actors.WholesaleClient)]
    public async Task<OfferConfirmed> Handle(ConfirmOffer command)
    {
            var (orderId, offer) = CreateDomainModelFrom(command);
            var order = await orders.GetBy(orderId);
            var clientId = await GetClient(orderId);
            var currentOffer = await calculatePrices.For(clientId,
                SalesChannel.Wholesale,
                offer.ProductAmounts,
                offer.Currency);
            if (!offer.Equals(currentOffer))
                throw new DomainError();
            var priceChangesPolicy = await priceChangesPolicies.ChooseFor(clientId);
            var now = clock.Now;
            order.ConfirmPrices(offer, priceChangesPolicy, now + _offerExpirationTime);
            await orders.Save(order);
            var offerConfirmed = CreateEventFrom(orderId, offer);
            eventsOutbox.Add(offerConfirmed);
            return offerConfirmed;
        }

    private static (OrderId, Offer) CreateDomainModelFrom(ConfirmOffer command) => (
        OrderId.From(command.OrderId),
        Offer.FromQuotes(command.CurrencyCode.ToDomainModel<Currency>(),
            command.Quotes.Select(quote => quote.ToDomainModel())));

    private async Task<ClientId> GetClient(OrderId orderId)
    {
            var orderHeader = await crudOperations.Read<OrderHeader>(orderId.Value);
            return ClientId.From(orderHeader.ClientId);
        }

    private static OfferConfirmed CreateEventFrom(OrderId orderId, Offer offer) => new(
        orderId.Value, offer.Quotes
            .Select(quote => quote.ToDto())
            .ToImmutableArray());
}