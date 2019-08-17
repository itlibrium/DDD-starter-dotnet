using System;
using System.Linq;
using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.TechnicalStuff;

namespace MyCompany.Crm.Sales.OnlineSales.PlaceOrder
{
    public class PlaceOrderHandler
    {
        private readonly CalculatePrices _calculatePrices;
        private readonly OrderRepository _orders;

        public PlaceOrderHandler(CalculatePrices calculatePrices, OrderRepository orders)
        {
            _calculatePrices = calculatePrices;
            _orders = orders;
        }

        public async Task<OrderPlaced> Handle(PlaceOrderCommand command)
        {
            var (clientId, offer) = CreateDomainModelFrom(command);
            var currentOffer = await _calculatePrices.For(clientId, offer.ProductAmounts, offer.Currency);
            if(!offer.Equals(currentOffer)) throw new DomainException();
            var order = Order.FromOffer(offer);
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