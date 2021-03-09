using System.Threading;
using System.Threading.Tasks;
using MyCompany.Crm.TechnicalStuff.Kafka;
using Newtonsoft.Json;

namespace MyCompany.Crm.TechnicalStuff.Outbox.Kafka
{
    public class OutboxMessageKafkaPublisher : OutboxMessagePublisher
    {
        public string SupportedMessageType => KafkaMessage.MessageType;

        private readonly KafkaMessageProducer _kafkaMessageProducer;

        public OutboxMessageKafkaPublisher(KafkaMessageProducer kafkaMessageProducer) =>
            _kafkaMessageProducer = kafkaMessageProducer;

        public Task Publish(OutboxMessage message, CancellationToken cancellationToken)
        {
            if (message.Type != SupportedMessageType)
            {
                // TODO: logging (fatal because it's a bug)
                return Task.CompletedTask;
            }
            var kafkaMessage = Deserialize(message.PayloadAsJson);
            if (kafkaMessage != null)
                _kafkaMessageProducer.Produce(kafkaMessage);
            return Task.CompletedTask;
        }

        private static KafkaMessage Deserialize(string payloadAsJson)
        {
            try
            {
                return JsonConvert.DeserializeObject<KafkaMessage>(payloadAsJson);
            }
            catch (JsonException jsonException)
            {
                // TODO: logging (fatal because it's a bug)
                return null;
            }
        }
    }
}