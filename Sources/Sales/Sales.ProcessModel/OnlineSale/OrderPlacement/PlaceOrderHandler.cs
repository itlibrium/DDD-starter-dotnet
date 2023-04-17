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
using MyCompany.Crm.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain.DynamicModel.DDD;

namespace MyCompany.Crm.Sales.OnlineSale.OrderPlacement
{
    [DddApplicationService]
    public class PlaceOrderHandler : CommandHandler<PlaceOrder, OrderPlaced>
    {
        private readonly CalculatePrices _calculatePrices;
        private readonly Order.Repository _orders;
        private readonly Order.Factory _facotry;
        private readonly SalesCrudOperations _crudOperations;
        private readonly OrderEventsOutbox _eventsOutbox;
        private readonly Clock _clock;
        
        public PlaceOrderHandler(CalculatePrices calculatePrices, Order.Repository orders, 
            SalesCrudOperations crudOperations, OrderEventsOutbox eventsOutbox, Clock clock)
        {
            _calculatePrices = calculatePrices;
            _orders = orders;
            _crudOperations = crudOperations;
            _eventsOutbox = eventsOutbox;
            _clock = clock;
        }

        public async Task<OrderPlaced> Handle(PlaceOrder command)
        {
            var (clientId, offer) = CreateDomainModelFrom(command);
            var currentOffer = await _calculatePrices.For(clientId,
                SalesChannel.OnlineSales,
                offer.ProductAmounts,
                offer.Currency);
            if (!offer.Equals(currentOffer)) throw new DomainError();
            var order = _facotry.ImmediatelyPlacedBasedOn(offer);
            var orderHeader = new OrderHeader
            {
                Id = order.Id.Value, 
                ClientId = clientId.Value, 
                InvoicingDetails = command.InvoicingDetails
            };
            await _orders.Save(order);
            await _crudOperations.Create(orderHeader);
            var orderPlaced = CreateEventFrom(clientId, order, _clock.Now);
            _eventsOutbox.Add(orderPlaced);
            return orderPlaced;
        }

        private static (ClientId, Offer) CreateDomainModelFrom(PlaceOrder command) => (
            ClientId.From(command.ClientId),
            Offer.FromQuotes(command.CurrencyCode.ToDomainModel<Currency>(),
                command.Quotes.Select(quote => quote.ToDomainModel())));

        private static OrderPlaced CreateEventFrom(ClientId clientId, Order order, DateTime placedOn) =>
            new(order.Id.Value, clientId.Value, placedOn);
    }
}