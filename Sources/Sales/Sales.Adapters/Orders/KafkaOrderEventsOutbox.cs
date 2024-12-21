using System.Diagnostics.CodeAnalysis;
using MyCompany.ECommerce.TechnicalStuff.Outbox;
using MyCompany.ECommerce.TechnicalStuff.Outbox.Kafka;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.Orders;

[method: SuppressMessage("ReSharper", "SuggestBaseTypeForParameter", Justification = "Required by DI container")]
public class KafkaOrderEventsOutbox(TransactionalOutboxes outboxes, TransactionalOutboxRepository repository,
    MessageTypes messageTypes) : TransactionalKafkaOutbox<OrderEvent>(outboxes, repository, messageTypes), OrderEventsOutbox
{
    protected override string Topic => "OrderEvents";

    protected override string GetPartitionKeyFor(OrderEvent message) => message.OrderId.ToString("N");
}