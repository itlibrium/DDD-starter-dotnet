using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using Newtonsoft.Json;

namespace MyCompany.ECommerce.TechnicalStuff.Outbox;

public abstract class InPlaceTransactionalOutbox<TMessage>(
    TransactionalOutboxes outboxes,
    TransactionalOutboxRepository repository,
    MessageTypes messageTypes)
    : TransactionalOutbox<TMessage>(outboxes, repository, messageTypes)
    where TMessage : Message
{
    protected override string GetProcessorTypeFor(TMessage message) => OutboxMessageProcessors.InPlace;

    protected override string CreatePayloadFrom(TMessage message) => JsonConvert.SerializeObject(message);
}