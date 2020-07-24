using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace MyCompany.Crm.TechnicalStuff.Kafka
{
    public class KafkaProducer : IDisposable
    {
        private readonly IProducer<string, string> _producer;

        public KafkaProducer(ProducerConfig config)
        {
            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        public Task Produce(KafkaMessage message) => _producer.ProduceAsync(message.Topic, new Message<string, string>
        {
            Key = message.Key,
            Value = message.Value
        });

        public Task Produce(IEnumerable<KafkaMessage> messages)
        {
            throw new NotImplementedException();
        }

        public void Dispose() => _producer.Dispose();
    }
}