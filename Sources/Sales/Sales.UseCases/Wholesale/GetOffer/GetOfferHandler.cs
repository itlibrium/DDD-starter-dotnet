using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.Sales.SalesChannels;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Sales.Wholesale.GetOffer
{
    [Stateless]
    [DddAppService]
    public class GetOfferHandler : CommandHandler<GetOffer, OfferCalculated>
    {
        private readonly OrderRepository _orders;
        private readonly SalesCrudOperations _crudOperations;
        private readonly CalculatePrices _calculatePrices;

        public GetOfferHandler(OrderRepository orders, SalesCrudOperations crudOperations,
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
            var offer = await _calculatePrices.For(clientId, SalesChannel.Wholesales, order.ProductAmounts, currency);
            return CreateEventFrom(orderId, offer);
        }

        private static (OrderId, Currency) CreateDomainModelFrom(GetOffer command) => (
            OrderId.From(command.OrderId), command.CurrencyCode.ToDomainModel<Currency>());
        
        private async Task<ClientId> GetClient(OrderId orderId)
        {
            var orderHeader = await _crudOperations.Read<OrderHeader>(orderId.Value);
            return ClientId.From(orderHeader.ClientId);
        }

        private static OfferCalculated CreateEventFrom(OrderId orderId, Offer offer) => new OfferCalculated(
            orderId.Value, offer.Quotes
                .Select(quote => quote.ToDto())
                .ToImmutableArray());
    }
}