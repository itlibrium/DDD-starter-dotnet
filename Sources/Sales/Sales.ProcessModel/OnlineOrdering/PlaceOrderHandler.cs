using JetBrains.Annotations;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Orders;
using MyCompany.ECommerce.Sales.Pricing;
using MyCompany.ECommerce.Sales.SalesChannels;
using MyCompany.ECommerce.Sales.Time;
using MyCompany.ECommerce.TechnicalStuff;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain;
using P3Model.Annotations.People;

namespace MyCompany.ECommerce.Sales.OnlineOrdering;

[UsedImplicitly]
public class PlaceOrderHandler(
    CalculatePrices calculatePrices,
    Order.Repository repository,
    Order.Factory factory,
    SalesCrudOperations crudOperations,
    OrderEventsOutbox eventsOutbox,
    Clock clock)
    : CommandHandler<PlaceOrder, OrderPlaced>
{
    [PublicContract]
    [Actor(Actors.RetailClient)]
    public async Task<OrderPlaced> Handle(PlaceOrder command)
    {
            var (clientId, offer) = CreateDomainModelFrom(command);
            var currentOffer = await calculatePrices.For(clientId,
                SalesChannel.OnlineSale,
                offer.ProductAmounts,
                offer.Currency);
            if (!offer.Equals(currentOffer)) throw new DomainError();
            var order = factory.ImmediatelyPlacedBasedOn(offer);
            var orderHeader = new OrderHeader
            {
                Id = order.Id.Value, 
                ClientId = clientId.Value, 
                InvoicingDetails = command.InvoicingDetails
            };
            await repository.Save(order);
            await crudOperations.Create(orderHeader);
            var orderPlaced = CreateEventFrom(clientId, order, clock.Now);
            eventsOutbox.Add(orderPlaced);
            return orderPlaced;
        }

    private static (ClientId, Offer) CreateDomainModelFrom(PlaceOrder command) => (
        ClientId.From(command.ClientId),
        Offer.FromQuotes(command.CurrencyCode.ToDomainModel<Currency>(),
            command.Quotes.Select(quote => quote.ToDomainModel())));

    private static OrderPlaced CreateEventFrom(ClientId clientId, Order order, DateTime placedOn) =>
        new(order.Id.Value, clientId.Value, placedOn);
}