using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCompany.Crm.TechnicalStuff.Outbox
{
    public interface TransactionalOutboxRepository
    {
        Task Save(IEnumerable<OutboxMessage> messages);
    }
}