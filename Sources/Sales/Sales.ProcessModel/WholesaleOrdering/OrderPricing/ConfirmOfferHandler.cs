using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
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
using P3Model.Annotations.Domain.StaticModel;
using P3Model.Annotations.Domain.StaticModel.DDD;
using P3Model.Annotations.People;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderPricing
{
    [ProcessStep(nameof(ConfirmOffer), Process = WholesaleOrderingProcess.Name)]
    [Actor(Actors.WholesaleClient)]
    [DddApplicationService]
    [UsedImplicitly]
    public class ConfirmOfferHandler : CommandHandler<ConfirmOffer, OfferConfirmed>
    {
        private readonly Order.Repository _orders;
        private readonly SalesCrudOperations _crudOperations;
        private readonly CalculatePrices _calculatePrices;
        private readonly PriceChangesPolicies _priceChangesPolicies;
        private readonly OrderEventsOutbox _eventsOutbox;
        private readonly Clock _clock;
        private readonly TimeSpan _offerExpirationTime = TimeSpan.FromHours(24);

        public ConfirmOfferHandler(Order.Repository orders,
            SalesCrudOperations crudOperations,
            CalculatePrices calculatePrices,
            PriceChangesPolicies priceChangesPolicies,
            OrderEventsOutbox eventsOutbox,
            Clock clock)
        {
            _orders = orders;
            _crudOperations = crudOperations;
            _calculatePrices = calculatePrices;
            _priceChangesPolicies = priceChangesPolicies;
            _eventsOutbox = eventsOutbox;
            _clock = clock;
        }

        public async Task<OfferConfirmed> Handle(ConfirmOffer command)
        {
            var (orderId, offer) = CreateDomainModelFrom(command);
            var order = await _orders.GetBy(orderId);
            var clientId = await GetClient(orderId);
            var currentOffer = await _calculatePrices.For(clientId,
                SalesChannel.Wholesale,
                offer.ProductAmounts,
                offer.Currency);
            if (!offer.Equals(currentOffer))
                throw new DomainError();
            var priceChangesPolicy = await _priceChangesPolicies.ChooseFor(clientId);
            var now = _clock.Now;
            order.ConfirmPrices(offer, priceChangesPolicy, now + _offerExpirationTime);
            await _orders.Save(order);
            var offerConfirmed = CreateEventFrom(orderId, offer);
            _eventsOutbox.Add(offerConfirmed);
            return offerConfirmed;
        }

        private static (OrderId, Offer) CreateDomainModelFrom(ConfirmOffer command) => (
            OrderId.From(command.OrderId),
            Offer.FromQuotes(command.CurrencyCode.ToDomainModel<Currency>(),
                command.Quotes.Select(quote => quote.ToDomainModel())));

        private async Task<ClientId> GetClient(OrderId orderId)
        {
            var orderHeader = await _crudOperations.Read<OrderHeader>(orderId.Value);
            return ClientId.From(orderHeader.ClientId);
        }

        private static OfferConfirmed CreateEventFrom(OrderId orderId, Offer offer) => new(
            orderId.Value, offer.Quotes
                .Select(quote => quote.ToDto())
                .ToImmutableArray());
    }
}