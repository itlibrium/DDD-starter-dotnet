using MyCompany.Crm.TechnicalStuff.ProcessModel;
using Newtonsoft.Json;

namespace MyCompany.Crm.TechnicalStuff.Outbox
{
    public abstract class InPlaceTransactionalOutbox<TMessage> : TransactionalOutbox<TMessage>
        where TMessage : Message
    {
        protected InPlaceTransactionalOutbox(TransactionalOutboxes outboxes, TransactionalOutboxRepository repository,
            MessageTypes messageTypes) : base(outboxes, repository, messageTypes) { }

        protected override string GetProcessorTypeFor(TMessage message) => OutboxMessageProcessors.InPlace;

        protected override string CreatePayloadFrom(TMessage message) => JsonConvert.SerializeObject(message);
    }
}