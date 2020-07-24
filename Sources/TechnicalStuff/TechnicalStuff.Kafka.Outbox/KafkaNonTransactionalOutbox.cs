using System.Collections.Generic;
using System.Threading.Tasks;
using MyCompany.Crm.TechnicalStuff.UseCases.Messages;

namespace MyCompany.Crm.TechnicalStuff.Kafka.Outbox
{
    public abstract class KafkaNonTransactionalOutbox<TMessage> : NonTransactionalOutbox
    {
        private readonly List<KafkaMessage> _kafkaMessages = new List<KafkaMessage>();
        private readonly KafkaProducer _kafkaProducer;

        protected KafkaNonTransactionalOutbox(KafkaProducer kafkaProducer, NonTransactionalOutboxes outboxes)
            : base(outboxes) =>
            _kafkaProducer = kafkaProducer;

        public void Add(TMessage message)
        {
            var kafkaMessage = ToKafkaMessage(message);
            _kafkaMessages.Add(kafkaMessage);
        }

        protected abstract KafkaMessage ToKafkaMessage(TMessage message);

        public override Task Send() => _kafkaProducer.Produce(_kafkaMessages);
    }
}