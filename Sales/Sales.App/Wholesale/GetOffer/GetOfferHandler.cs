using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.Sales.SalesChannels;
using MyCompany.Crm.TechnicalStuff;

namespace MyCompany.Crm.Sales.Wholesale.GetOffer
{
    public class GetOfferHandler
    {
        private readonly OrderRepository _orders;
        private readonly OrderHeaderRepository _orderHeaders;
        private readonly CalculatePrices _calculatePrices;

        public GetOfferHandler(OrderRepository orders, OrderHeaderRepository orderHeaders,
            CalculatePrices calculatePrices)
        {
            _orders = orders;
            _orderHeaders = orderHeaders;
            _calculatePrices = calculatePrices;
        }

        public async Task<OfferCalculated> Handle(GetOfferCommand command)
        {
            var (orderId, currency) = CreateDomainModelFrom(command);
            var order = await _orders.GetBy(orderId);
            var orderHeader = await _orderHeaders.GetBy(orderId);
            var offer = await _calculatePrices.For(orderHeader.ClientId, SalesChannel.Wholesales, order.ProductAmounts,
                currency);
            return CreateEventFrom(orderId, offer);
        }

        private static (OrderId, Currency) CreateDomainModelFrom(GetOfferCommand command) => (
            OrderId.From(command.OrderId), command.CurrencyCode.ToDomainModel<Currency>());

        private static OfferCalculated CreateEventFrom(OrderId orderId, Offer offer) => new OfferCalculated(
            orderId.Value, offer.Quotes
                .Select(quote => quote.ToDto())
                .ToImmutableArray());
    }
}