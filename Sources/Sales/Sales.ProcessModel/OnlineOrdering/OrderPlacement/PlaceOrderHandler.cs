using System;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Orders;
using MyCompany.ECommerce.Sales.Pricing;
using MyCompany.ECommerce.Sales.SalesChannels;
using MyCompany.ECommerce.Sales.Time;
using MyCompany.ECommerce.TechnicalStuff;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain.StaticModel;
using P3Model.Annotations.Domain.StaticModel.DDD;
using P3Model.Annotations.People;

namespace MyCompany.ECommerce.Sales.OnlineOrdering.OrderPlacement
{
    [UsedImplicitly]
    [ProcessStep(nameof(PlaceOrder), Process = OnlineOrderingProcess.Name)]
    [Actor(Actors.RetailClient)]
    [DddApplicationService]
    public class PlaceOrderHandler : CommandHandler<PlaceOrder, OrderPlaced>
    {
        private readonly CalculatePrices _calculatePrices;
        private readonly Order.Repository _repository;
        private readonly Order.Factory _factory;
        private readonly SalesCrudOperations _crudOperations;
        private readonly OrderEventsOutbox _eventsOutbox;
        private readonly Clock _clock;
        
        public PlaceOrderHandler(CalculatePrices calculatePrices, Order.Repository repository, Order.Factory factory, 
            SalesCrudOperations crudOperations, OrderEventsOutbox eventsOutbox, Clock clock)
        {
            _calculatePrices = calculatePrices;
            _repository = repository;
            _factory = factory;
            _crudOperations = crudOperations;
            _eventsOutbox = eventsOutbox;
            _clock = clock;
        }

        public async Task<OrderPlaced> Handle(PlaceOrder command)
        {
            var (clientId, offer) = CreateDomainModelFrom(command);
            var currentOffer = await _calculatePrices.For(clientId,
                SalesChannel.OnlineSale,
                offer.ProductAmounts,
                offer.Currency);
            if (!offer.Equals(currentOffer)) throw new DomainError();
            var order = _factory.ImmediatelyPlacedBasedOn(offer);
            var orderHeader = new OrderHeader
            {
                Id = order.Id.Value, 
                ClientId = clientId.Value, 
                InvoicingDetails = command.InvoicingDetails
            };
            await _repository.Save(order);
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