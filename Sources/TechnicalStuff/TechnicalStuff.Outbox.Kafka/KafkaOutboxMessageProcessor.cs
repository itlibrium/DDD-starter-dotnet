using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MyCompany.ECommerce.TechnicalStuff.Kafka;
using Newtonsoft.Json;

namespace MyCompany.ECommerce.TechnicalStuff.Outbox.Kafka
{
    public class KafkaOutboxMessageProcessor : OutboxMessageProcessor
    {
        public string ProcessorType => OutboxMessageProcessors.Kafka;

        private readonly KafkaMessageProducer _kafkaMessageProducer;
        private readonly ILogger<KafkaOutboxMessageProcessor> _logger;

        public KafkaOutboxMessageProcessor(KafkaMessageProducer kafkaMessageProducer,
            ILogger<KafkaOutboxMessageProcessor> logger)
        {
            _kafkaMessageProducer = kafkaMessageProducer;
            _logger = logger;
        }

        public async Task<MessageProcessingResult> Process(OutboxMessage outboxMessage,
            CancellationToken cancellationToken)
        {
            if (!CheckProcessorTypeFor(outboxMessage))
                return MessageProcessingResult.MessageUnprocessable;
            if (!TryDeserialize(outboxMessage, out var kafkaMessage))
                return MessageProcessingResult.MessageUnprocessable;
            return await Produce(kafkaMessage, cancellationToken);
        }

        private bool CheckProcessorTypeFor(OutboxMessage outboxMessage)
        {
            if (outboxMessage.ProcessorType == ProcessorType)
                return true;
            _logger.LogCritical(
                "Wrong OutboxMessageProcessor. Message {MessageId}, actual processor: {ActualProcessorType}, required processor: {RequiredProcessorType}",
                outboxMessage.Id, ProcessorType, outboxMessage.ProcessorType);
            return false;
        }

        private bool TryDeserialize(OutboxMessage outboxMessage, out KafkaMessage kafkaMessage)
        {
            try
            {
                kafkaMessage = JsonConvert.DeserializeObject<KafkaMessage>(outboxMessage.PayloadAsJson);
                return true;
            }
            catch (JsonException e)
            {
                _logger.LogCritical(e, "Message deserialization failed. Message id: {MessageId}", outboxMessage.Id);
                kafkaMessage = null;
                return false;
            }
        }

        private async Task<MessageProcessingResult> Produce(KafkaMessage kafkaMessage,
            CancellationToken cancellationToken)
        {
            var result = await _kafkaMessageProducer.Produce(kafkaMessage, cancellationToken);
            return result switch
            {
                KafkaProducerResult.NoError => MessageProcessingResult.Processed,
                KafkaProducerResult.InvalidMessage => MessageProcessingResult.MessageUnprocessable,
                KafkaProducerResult.NoAck => MessageProcessingResult.TemporaryError,
                KafkaProducerResult.OtherError => MessageProcessingResult.TemporaryError,
                _ => throw new ArgumentOutOfRangeException(nameof(result))
            };
        }
    }
}