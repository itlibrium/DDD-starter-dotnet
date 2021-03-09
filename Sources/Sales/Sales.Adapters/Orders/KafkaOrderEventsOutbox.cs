using System.Diagnostics.CodeAnalysis;
using MyCompany.Crm.TechnicalStuff.Outbox;
using MyCompany.Crm.TechnicalStuff.Outbox.Kafka;
using MyCompany.Crm.TechnicalStuff.Outbox.Postgres;

namespace MyCompany.Crm.Sales.Orders
{
    public class KafkaOrderEventsOutbox : TransactionalKafkaOutbox<OrderEvent>, OrderEventsOutbox
    {
        protected override string Topic => "OrderEvents";

        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter", Justification = "Required by DI container")]
        public KafkaOrderEventsOutbox(TransactionalOutboxes outboxes,
            TransactionalOutboxPostgresRepository<SalesDb> repository)
            : base(outboxes, repository) { }

        protected override string GetKeyFor(OrderEvent orderEvent) => orderEvent.OrderId.ToString();
    }
}