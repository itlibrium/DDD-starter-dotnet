using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MyCompany.ECommerce.TechnicalStuff.Kafka;

namespace MyCompany.ECommerce.TechnicalStuff.Outbox.Kafka
{
    public abstract class NonTransactionalKafkaOutbox<TMessage> : NonTransactionalOutbox
    {
        private readonly List<KafkaMessage> _kafkaMessages = new();
        private readonly KafkaMessageProducer _kafkaMessageProducer;

        protected NonTransactionalKafkaOutbox(KafkaMessageProducer kafkaMessageProducer,
            NonTransactionalOutboxes outboxes)
            : base(outboxes) =>
            _kafkaMessageProducer = kafkaMessageProducer;

        public void Add(TMessage message)
        {
            var kafkaMessage = ToKafkaMessage(message);
            _kafkaMessages.Add(kafkaMessage);
        }

        protected abstract KafkaMessage ToKafkaMessage(TMessage message);

        public override Task Send()
        {
            foreach (var kafkaMessage in _kafkaMessages)
                _kafkaMessageProducer.Produce(kafkaMessage, CancellationToken.None);
            _kafkaMessages.Clear();
            return Task.CompletedTask;
        }
    }
}