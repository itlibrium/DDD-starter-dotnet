using System.Diagnostics.CodeAnalysis;
using MyCompany.ECommerce.TechnicalStuff.Outbox;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.Orders
{
    public class InPlaceOrderEventsOutbox : InPlaceTransactionalOutbox<OrderEvent>, OrderEventsOutbox
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameterInConstructor",
            Justification = "Required by DI container")]
        public InPlaceOrderEventsOutbox(TransactionalOutboxes outboxes, TransactionalOutboxRepository repository,
            MessageTypes messageTypes)
            : base(outboxes, repository, messageTypes) { }

        protected override string GetPartitionKeyFor(OrderEvent message) => message.OrderId.ToString("N");
    }
}