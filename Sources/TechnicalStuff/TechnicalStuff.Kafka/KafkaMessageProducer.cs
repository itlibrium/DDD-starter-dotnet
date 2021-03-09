using System;
using Confluent.Kafka;

namespace MyCompany.Crm.TechnicalStuff.Kafka
{
    public class KafkaMessageProducer : IDisposable
    {
        private readonly IProducer<string, string> _producer;

        public KafkaMessageProducer(ProducerConfig config) =>
            _producer = new ProducerBuilder<string, string>(config).Build();

        public KafkaMessageProducer(IProducer<string, string> producer) => _producer = producer;

        public void Produce(KafkaMessage message) =>
            _producer.Produce(message.Topic,
                new Message<string, string> {Key = message.Key, Value = message.ValueAsJson},
                report => ErrorHandler(report));

        // TODO: flexible error handling
        private static void ErrorHandler(DeliveryReport<string, string> report)
        {
            if (report.Error.Code == ErrorCode.NoError)
                return;
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            // TODO: configurable timeout, loop with checking result
            _producer.Flush(TimeSpan.FromMilliseconds(1000));
            _producer.Dispose();
        }
    }
}