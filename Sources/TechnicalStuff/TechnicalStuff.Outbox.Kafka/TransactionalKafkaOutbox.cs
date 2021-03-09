using System;
using MyCompany.Crm.TechnicalStuff.Kafka;
using Newtonsoft.Json;

namespace MyCompany.Crm.TechnicalStuff.Outbox.Kafka
{
    public abstract class TransactionalKafkaOutbox<TMessage> : TransactionalOutbox
    {
        protected abstract string Topic { get; }

        protected TransactionalKafkaOutbox(TransactionalOutboxes outboxes, TransactionalOutboxRepository repository)
            : base(outboxes, repository) { }

        public void Add(TMessage message)
        {
            var kafkaMessage = new KafkaMessage(
                Topic,
                GetKeyFor(message),
                Serialize(message));
            var outboxMessage = new OutboxMessage(
                Guid.NewGuid(),
                KafkaMessage.MessageType,
                Serialize(kafkaMessage));
            Add(outboxMessage);
        }

        protected abstract string GetKeyFor(TMessage message);

        // TODO: flexible serialization (json, avro, etc. - Kafka specific)
        private static string Serialize(TMessage message) => JsonConvert.SerializeObject(message);
        
        private static string Serialize(KafkaMessage kafkaMessage) => JsonConvert.SerializeObject(kafkaMessage);
    }
}