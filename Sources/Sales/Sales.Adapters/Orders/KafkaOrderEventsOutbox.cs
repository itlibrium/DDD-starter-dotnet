using System.Diagnostics.CodeAnalysis;
using MyCompany.ECommerce.TechnicalStuff.Outbox;
using MyCompany.ECommerce.TechnicalStuff.Outbox.Kafka;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.Orders;

public class KafkaOrderEventsOutbox : TransactionalKafkaOutbox<OrderEvent>, OrderEventsOutbox
{
    protected override string Topic => "OrderEvents";

    [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter", Justification = "Required by DI container")]
    public KafkaOrderEventsOutbox(TransactionalOutboxes outboxes, TransactionalOutboxRepository repository,
        MessageTypes messageTypes)
        : base(outboxes, repository, messageTypes) { }
        
    protected override string GetPartitionKeyFor(OrderEvent message) => message.OrderId.ToString("N");
}