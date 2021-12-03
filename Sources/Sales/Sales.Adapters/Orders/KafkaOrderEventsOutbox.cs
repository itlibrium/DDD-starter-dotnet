using System.Diagnostics.CodeAnalysis;
using MyCompany.Crm.TechnicalStuff.Outbox;
using MyCompany.Crm.TechnicalStuff.Outbox.Kafka;
using MyCompany.Crm.TechnicalStuff.Outbox.Postgres;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Sales.Orders
{
    public class KafkaOrderEventsOutbox : TransactionalKafkaOutbox<OrderEvent>, OrderEventsOutbox
    {
        protected override string Topic => "OrderEvents";

        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter", Justification = "Required by DI container")]
        public KafkaOrderEventsOutbox(TransactionalOutboxes outboxes, PostgresOutboxRepository<SalesDb> repository,
            MessageTypes messageTypes)
            : base(outboxes, repository, messageTypes) { }
        
        protected override string GetPartitionKeyFor(OrderEvent message) => message.OrderId.ToString("N");
    }
}