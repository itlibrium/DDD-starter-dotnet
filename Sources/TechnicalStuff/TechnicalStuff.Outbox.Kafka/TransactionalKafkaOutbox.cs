using MyCompany.Crm.TechnicalStuff.Kafka;
using MyCompany.Crm.TechnicalStuff.UseCases;
using Newtonsoft.Json;

namespace MyCompany.Crm.TechnicalStuff.Outbox.Kafka
{
    public abstract class TransactionalKafkaOutbox<TMessage> : TransactionalOutbox<TMessage>
        where TMessage : Message
    {
        protected abstract string Topic { get; }

        protected TransactionalKafkaOutbox(TransactionalOutboxes outboxes, TransactionalOutboxRepository repository,
            MessageTypes messageTypes) : base(outboxes, repository, messageTypes) { }

        protected override string GetProcessorTypeFor(TMessage message) => OutboxMessageProcessors.Kafka;

        protected override string CreatePayloadFrom(TMessage message)
        {
            var kafkaMessage = new KafkaMessage(Topic,
                GetPartitionKeyFor(message),
                Serialize(message));
            return Serialize(kafkaMessage);
        }

        // TODO: flexible serialization (json, avro, etc. - Kafka specific)
        private static string Serialize(TMessage message) => JsonConvert.SerializeObject(message);

        private static string Serialize(KafkaMessage kafkaMessage) => JsonConvert.SerializeObject(kafkaMessage);
    }
}