using MyCompany.ECommerce.TechnicalStuff.Kafka;

namespace MyCompany.ECommerce.TechnicalStuff.Outbox.Kafka;

public abstract class NonTransactionalKafkaOutbox<TMessage>(
    KafkaMessageProducer kafkaMessageProducer,
    NonTransactionalOutboxes outboxes)
    : NonTransactionalOutbox(outboxes)
{
    private readonly List<KafkaMessage> _kafkaMessages = new();

    public void Add(TMessage message)
    {
        var kafkaMessage = ToKafkaMessage(message);
        _kafkaMessages.Add(kafkaMessage);
    }

    protected abstract KafkaMessage ToKafkaMessage(TMessage message);

    public override Task Send()
    {
        foreach (var kafkaMessage in _kafkaMessages)
            kafkaMessageProducer.Produce(kafkaMessage, CancellationToken.None);
        _kafkaMessages.Clear();
        return Task.CompletedTask;
    }
}