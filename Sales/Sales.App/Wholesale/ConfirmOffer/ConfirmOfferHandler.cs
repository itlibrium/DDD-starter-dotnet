using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.Sales.Pricing;

namespace MyCompany.Crm.Sales.Wholesale.ConfirmOffer
{
    public class ConfirmOfferHandler
    {
        private readonly OrderRepository _orders;
        private readonly OrderHeaderRepository _orderHeaders;
        private readonly CalculatePrices _calculatePrices;

        public ConfirmOfferHandler(OrderRepository orders, OrderHeaderRepository orderHeaders,
            CalculatePrices calculatePrices)
        {
            _orders = orders;
            _orderHeaders = orderHeaders;
            _calculatePrices = calculatePrices;
        }

        public async Task<OfferConfirmed> Handle(ConfirmOfferCommand command)
        {
            var (orderId, offer) = CreateDomainModelFrom(command);
            var order = await _orders.GetBy(orderId);
            var orderHeader = await _orderHeaders.GetBy(orderId);
            var currentOffer = await _calculatePrices.For(orderHeader.ClientId, offer.ProductAmounts, offer.Currency);
            if(!offer.Equals(currentOffer)) throw new DomainException();
            order.ConfirmPrices(offer);
            await _orders.Save(order);
            return CreateEventFrom(orderId, offer);
        }

        private static (OrderId, Offer) CreateDomainModelFrom(ConfirmOfferCommand command) => (
            OrderId.From(command.OrderId),
            Offer.FromQuotes(command.Quotes.Select(quote => quote.ToDomainModel())));
        
        private static OfferConfirmed CreateEventFrom(OrderId orderId, Offer offer) => new OfferConfirmed(
            orderId.Value, offer.Quotes
                .Select(quote => quote.ToDto())
                .ToImmutableArray());
    }
}