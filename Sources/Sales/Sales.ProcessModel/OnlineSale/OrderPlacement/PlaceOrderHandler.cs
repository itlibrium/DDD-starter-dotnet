using System;
using System.Linq;
using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.Sales.SalesChannels;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Sales.OnlineSale.OrderPlacement
{
    [DddAppService]
    public class PlaceOrderHandler : CommandHandler<PlaceOrder, OrderPlaced>
    {
        private readonly CalculatePrices _calculatePrices;
        private readonly OrderRepository _orders;
        private readonly SalesCrudOperations _crudOperations;
        private readonly OrderEventsOutbox _eventsOutbox;

        public PlaceOrderHandler(CalculatePrices calculatePrices, OrderRepository orders, 
            SalesCrudOperations crudOperations, OrderEventsOutbox eventsOutbox)
        {
            _calculatePrices = calculatePrices;
            _orders = orders;
            _crudOperations = crudOperations;
            _eventsOutbox = eventsOutbox;
        }

        public async Task<OrderPlaced> Handle(PlaceOrder command)
        {
            var (clientId, offer) = CreateDomainModelFrom(command);
            var currentOffer = await _calculatePrices.For(clientId,
                SalesChannel.OnlineSales,
                offer.ProductAmounts,
                offer.Currency);
            if (!offer.Equals(currentOffer)) throw new DomainException();
            var order = Order.FromOffer(offer);
            var orderHeader = new OrderHeader
            {
                Id = order.Id.Value, 
                ClientId = clientId.Value, 
                InvoicingDetails = command.InvoicingDetails
            };
            await _orders.Save(order);
            await _crudOperations.Create(orderHeader);
            var orderPlaced = CreateEventFrom(clientId, order);
            _eventsOutbox.Add(orderPlaced);
            return orderPlaced;
        }

        private static (ClientId, Offer) CreateDomainModelFrom(PlaceOrder command) => (
            ClientId.From(command.ClientId),
            Offer.FromQuotes(command.CurrencyCode.ToDomainModel<Currency>(),
                command.Quotes.Select(quote => quote.ToDomainModel())));

        private static OrderPlaced CreateEventFrom(ClientId clientId, Order order) =>
            new OrderPlaced(order.Id.Value, clientId.Value, DateTime.UtcNow);
    }
}