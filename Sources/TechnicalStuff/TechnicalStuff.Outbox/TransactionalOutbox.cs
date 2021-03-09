using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCompany.Crm.TechnicalStuff.Outbox
{
    public abstract class TransactionalOutbox
    {
        private readonly List<OutboxMessage> _messages = new List<OutboxMessage>();
        private readonly TransactionalOutboxRepository _repository;
        
        protected TransactionalOutbox(TransactionalOutboxes outboxes, TransactionalOutboxRepository repository)
        {
            outboxes.Register(this);
            _repository = repository;
        }

        protected void Add(OutboxMessage message) => _messages.Add(message);
        
        protected void Add(IEnumerable<OutboxMessage> messages) => _messages.AddRange(messages);

        public Task Save() => _repository.Save(_messages);
    }
}