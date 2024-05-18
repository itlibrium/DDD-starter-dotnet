using System.Collections.Immutable;
using JetBrains.Annotations;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Orders;
using MyCompany.ECommerce.Sales.Pricing;
using MyCompany.ECommerce.Sales.SalesChannels;
using MyCompany.ECommerce.TechnicalStuff;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain;
using P3Model.Annotations.People;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderPricing;

[UsedImplicitly]
public class GetOfferHandler(
    Order.Repository orders,
    SalesCrudOperations crudOperations,
    CalculatePrices calculatePrices)
    : CommandHandler<GetOffer, OfferCalculated>
{
    [UseCase(nameof(GetOffer), Process = WholesaleOrderingProcess.Name)]
    [Actor(Actors.WholesaleClient)]
    public async Task<OfferCalculated> Handle(GetOffer command)
    {
            var (orderId, currency) = CreateDomainModelFrom(command);
            var order = await orders.GetBy(orderId);
            var clientId = await GetClient(orderId);
            var offer = await calculatePrices.For(clientId, SalesChannel.Wholesale, order.ProductAmounts, currency);
            return CreateEventFrom(orderId, offer);
        }

    private static (OrderId, Currency) CreateDomainModelFrom(GetOffer command) => (
        OrderId.From(command.OrderId), command.CurrencyCode.ToDomainModel<Currency>());

    private async Task<ClientId> GetClient(OrderId orderId)
    {
            var orderHeader = await crudOperations.Read<OrderHeader>(orderId.Value);
            return ClientId.From(orderHeader.ClientId);
        }

    private static OfferCalculated CreateEventFrom(OrderId orderId, Offer offer) => new(
        orderId.Value, offer.Quotes
            .Select(quote => quote.ToDto())
            .ToImmutableArray());
}