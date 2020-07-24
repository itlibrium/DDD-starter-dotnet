using System.Collections.Generic;
using System.Threading.Tasks;
using MyCompany.Crm.TechnicalStuff.UseCases.Messages;

namespace MyCompany.Crm.TechnicalStuff.Kafka.Outbox
{
    public abstract class KafkaTransactionalOutbox<TMessage> : TransactionalOutbox
    {
        private readonly List<KafkaMessage> _kafkaMessages = new List<KafkaMessage>();
        private readonly KafkaOutboxWriter _outboxWriter;

        protected KafkaTransactionalOutbox(KafkaOutboxWriter outboxWriter, TransactionalOutboxes outboxes)
            : base(outboxes) =>
            _outboxWriter = outboxWriter;

        public void Add(TMessage message)
        {
            var kafkaMessage = ToKafkaMessage(message);
            _kafkaMessages.Add(kafkaMessage);
        }
        
        protected abstract KafkaMessage ToKafkaMessage(TMessage message);
        
        public override Task Save() => _outboxWriter.Write(_kafkaMessages);

        
    }
}