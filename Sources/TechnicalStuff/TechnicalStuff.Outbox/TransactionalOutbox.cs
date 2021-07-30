using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.TechnicalStuff.Outbox
{
    public abstract class TransactionalOutbox
    {
        private readonly List<OutboxMessage> _messages = new();
        private readonly TransactionalOutboxRepository _repository;

        protected TransactionalOutbox(TransactionalOutboxes outboxes, TransactionalOutboxRepository repository)
        {
            outboxes.Register(this);
            _repository = repository;
        }

        public Task Save() => _repository.Save(_messages);

        protected void Add(string processorType, string messageTypeId, string payload) =>
            _messages.Add(new OutboxMessage(Guid.NewGuid(), processorType, messageTypeId, payload));
    }

    public abstract class TransactionalOutbox<TMessage> : TransactionalOutbox
        where TMessage : Message
    {
        private readonly MessageTypes _messageTypes;

        protected TransactionalOutbox(TransactionalOutboxes outboxes, TransactionalOutboxRepository repository,
            MessageTypes messageTypes) :
            base(outboxes, repository) =>
            _messageTypes = messageTypes;

        public void Add(TMessage message)
        {
            var processorType = GetProcessorTypeFor(message);
            var messageTypeId = _messageTypes.GetTypeIdFor(message);
            var payload = CreatePayloadFrom(message);
            Add(processorType, messageTypeId, payload);
        }

        protected abstract string GetProcessorTypeFor(TMessage message);

        protected abstract string CreatePayloadFrom(TMessage message);
    }
}