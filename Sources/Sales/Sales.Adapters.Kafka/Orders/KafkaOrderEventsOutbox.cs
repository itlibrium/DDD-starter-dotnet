using System;
using System.Diagnostics.CodeAnalysis;
using MyCompany.Crm.TechnicalStuff.Kafka;
using MyCompany.Crm.TechnicalStuff.Kafka.Outbox;
using MyCompany.Crm.TechnicalStuff.UseCases.Messages;

namespace MyCompany.Crm.Sales.Orders
{
    public class KafkaOrderEventsOutbox : KafkaTransactionalOutbox<OrderEvent>, OrderEventsOutbox
    {
        private const string Topic = "OrderEvents";

        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter", Justification = "DI registration")]
        public KafkaOrderEventsOutbox(SalesKafkaOutboxWriter outboxWriter, TransactionalOutboxes outboxes)
            : base(outboxWriter, outboxes) { }

        protected override KafkaMessage ToKafkaMessage(OrderEvent orderEvent) => new KafkaMessage(
            Topic,
            orderEvent.OrderId.ToString(),
            Serialize(orderEvent));

        private static string Serialize(OrderEvent orderEvent) => throw new NotImplementedException();
    }
}