using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCompany.ECommerce.TechnicalStuff.Outbox
{
    public interface TransactionalOutboxRepository
    {
        Task Save(IEnumerable<OutboxMessage> messages);
    }
}