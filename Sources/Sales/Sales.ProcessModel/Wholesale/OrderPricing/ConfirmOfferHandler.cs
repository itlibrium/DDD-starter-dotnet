using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.Sales.Orders.PriceChanges;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.Sales.SalesChannels;
using MyCompany.Crm.Sales.Time;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;
using MyCompany.Crm.TechnicalStuff.ProcessModel;

namespace MyCompany.Crm.Sales.Wholesale.OrderPricing
{
    [DddAppService]
    public class ConfirmOfferHandler  : CommandHandler<ConfirmOffer, OfferConfirmed>
    {
        private readonly OrderRepository _orders;
        private readonly SalesCrudOperations _crudOperations;
        private readonly CalculatePrices _calculatePrices;
        private readonly PriceChangesPolicies _priceChangesPolicies;
        private readonly OrderEventsOutbox _eventsOutbox;
        private readonly Clock _clock;
        private readonly TimeSpan _offerExpirationTime = TimeSpan.FromHours(24);

        public ConfirmOfferHandler(OrderRepository orders, 
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
                SalesChannel.Wholesales,
                offer.ProductAmounts,
                offer.Currency);
            if (!offer.Equals(currentOffer))
                throw new DomainError();
            var priceChangesPolicy = await _priceChangesPolicies.ChooseFor(clientId);
            var now = _clock.Now;
            order.ConfirmPrices(offer, now + _offerExpirationTime, now, priceChangesPolicy);
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