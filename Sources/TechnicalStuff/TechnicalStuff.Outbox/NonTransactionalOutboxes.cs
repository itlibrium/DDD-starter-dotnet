using System.Collections.Generic;

namespace MyCompany.Crm.TechnicalStuff.Outbox
{
    public class NonTransactionalOutboxes
    {
        private readonly List<NonTransactionalOutbox> _outboxes = new();
        public IReadOnlyList<NonTransactionalOutbox> ForCurrentUseCase => _outboxes.AsReadOnly();

        public void Register(NonTransactionalOutbox outbox) => _outboxes.Add(outbox);
    }
}