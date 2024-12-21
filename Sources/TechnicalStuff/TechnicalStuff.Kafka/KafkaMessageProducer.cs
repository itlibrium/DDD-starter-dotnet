using System.Collections.Immutable;
using Confluent.Kafka;
using Microsoft.Extensions.Logging;

namespace MyCompany.ECommerce.TechnicalStuff.Kafka;

public class KafkaMessageProducer(ProducerConfig config, ILogger<KafkaMessageProducer> logger)
    : IDisposable
{
    private static readonly ImmutableHashSet<ErrorCode> InvalidMessageErrors = new HashSet<ErrorCode>
    {
        ErrorCode.Local_BadMsg,
        ErrorCode.Local_KeySerialization,
        ErrorCode.Local_ValueSerialization,
        ErrorCode.InvalidMsg,
        ErrorCode.InvalidMsgSize,
        ErrorCode.MsgSizeTooLarge
    }.ToImmutableHashSet();

    private readonly IProducer<string, string> _producer = new ProducerBuilder<string, string>(config).Build();

    public async Task<KafkaProducerResult> Produce(KafkaMessage message, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _producer.ProduceAsync(message.Topic,
                new Message<string, string> {Key = message.Key, Value = message.ValueAsJson},
                cancellationToken);
            return result.Status == PersistenceStatus.Persisted
                ? KafkaProducerResult.NoError
                : KafkaProducerResult.NoAck;
        }
        catch (ProduceException<string, string> e)
        {
            logger.LogError(e, "Kafka producer failed");
            return InvalidMessageErrors.Contains(e.Error.Code)
                ? KafkaProducerResult.InvalidMessage
                : KafkaProducerResult.OtherError;
        }
    }

    public void Dispose() => _producer.Dispose();
}