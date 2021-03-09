using System.Collections.Generic;

namespace MyCompany.Crm.TechnicalStuff.Outbox
{
    public class TransactionalOutboxes
    {
        private readonly List<TransactionalOutbox> _outboxes = new List<TransactionalOutbox>();
        public IReadOnlyList<TransactionalOutbox> ForCurrentUseCase => _outboxes.AsReadOnly();

        public void Register(TransactionalOutbox outbox) => _outboxes.Add(outbox);
    }
}