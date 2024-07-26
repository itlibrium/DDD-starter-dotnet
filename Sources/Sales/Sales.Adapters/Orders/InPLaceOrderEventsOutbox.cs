using System.Diagnostics.CodeAnalysis;
using MyCompany.ECommerce.TechnicalStuff.Outbox;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.Orders;

[method: SuppressMessage("ReSharper", "SuggestBaseTypeForParameterInConstructor",
        Justification = "Required by DI container")]
public class InPlaceOrderEventsOutbox(TransactionalOutboxes outboxes, TransactionalOutboxRepository repository,
    MessageTypes messageTypes) : InPlaceTransactionalOutbox<OrderEvent>(outboxes, repository, messageTypes), OrderEventsOutbox
{
    protected override string GetPartitionKeyFor(OrderEvent message) => message.OrderId.ToString("N");
}