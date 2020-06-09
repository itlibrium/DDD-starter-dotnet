using System;
using System.Linq;
using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.Sales.SalesChannels;
using MyCompany.Crm.Sales.Time;
using MyCompany.Crm.TechnicalStuff;

namespace MyCompany.Crm.Sales.OnlineSales.PlaceOrder
{
    public class PlaceOrderHandler
    {
        private readonly CalculatePrices _calculatePrices;
        private readonly OrderRepository _orders;
        private readonly Clock _clock;
        private readonly TimeSpan _offerExpirationTime = TimeSpan.FromDays(5);

        public PlaceOrderHandler(CalculatePrices calculatePrices, OrderRepository orders, Clock clock)
        {
            _calculatePrices = calculatePrices;
            _orders = orders;
            _clock = clock;
        }

        public async Task<OrderPlaced> Handle(PlaceOrderCommand command)
        {
            var (clientId, offer) = CreateDomainModelFrom(command);
            var currentOffer = await _calculatePrices.For(clientId, SalesChannel.OnlineSales, offer.ProductAmounts, offer.Currency);
            if(!offer.Equals(currentOffer)) throw new DomainException();
            var order = Order.FromOffer(offer, _clock.Now + _offerExpirationTime);
            await _orders.Save(order);
            return CreateEventFrom(clientId, order);
        }

        private static (ClientId, Offer) CreateDomainModelFrom(PlaceOrderCommand command) => (
            ClientId.From(command.ClientId),
            Offer.FromQuotes(command.CurrencyCode.ToDomainModel<Currency>(), 
                command.Quotes.Select(quote => quote.ToDomainModel())));

        private static OrderPlaced CreateEventFrom(ClientId clientId, Order order) => 
            new OrderPlaced(order.Id.Value, clientId.Value, DateTime.UtcNow);
    }
}