using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Orders;
using MyCompany.ECommerce.Sales.Pricing;
using MyCompany.ECommerce.Sales.SalesChannels;
using MyCompany.ECommerce.TechnicalStuff;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain.DynamicModel;
using P3Model.Annotations.Domain.DynamicModel.DDD;
using P3Model.Annotations.People;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderPricing
{
    [ProcessStep(nameof(GetOffer), WholesaleOrderingProcess.Name,
        nameof(ConfirmOffer))]
    [Actor(Actors.WholesaleClient)]
    [DddApplicationService]
    public class GetOfferHandler : CommandHandler<GetOffer, OfferCalculated>
    {
        private readonly Order.Repository _orders;
        private readonly SalesCrudOperations _crudOperations;
        private readonly CalculatePrices _calculatePrices;

        public GetOfferHandler(Order.Repository orders, SalesCrudOperations crudOperations,
            CalculatePrices calculatePrices)
        {
            _orders = orders;
            _crudOperations = crudOperations;
            _calculatePrices = calculatePrices;
        }

        public async Task<OfferCalculated> Handle(GetOffer command)
        {
            var (orderId, currency) = CreateDomainModelFrom(command);
            var order = await _orders.GetBy(orderId);
            var clientId = await GetClient(orderId);
            var offer = await _calculatePrices.For(clientId, SalesChannel.Wholesale, order.ProductAmounts, currency);
            return CreateEventFrom(orderId, offer);
        }

        private static (OrderId, Currency) CreateDomainModelFrom(GetOffer command) => (
            OrderId.From(command.OrderId), command.CurrencyCode.ToDomainModel<Currency>());
        
        private async Task<ClientId> GetClient(OrderId orderId)
        {
            var orderHeader = await _crudOperations.Read<OrderHeader>(orderId.Value);
            return ClientId.From(orderHeader.ClientId);
        }

        private static OfferCalculated CreateEventFrom(OrderId orderId, Offer offer) => new(
            orderId.Value, offer.Quotes
                .Select(quote => quote.ToDto())
                .ToImmutableArray());
    }
}