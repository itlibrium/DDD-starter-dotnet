using System.Threading.Tasks;

namespace MyCompany.Crm.TechnicalStuff.Outbox
{
    public abstract class NonTransactionalOutbox
    {
        protected NonTransactionalOutbox(NonTransactionalOutboxes outboxes) => outboxes.Register(this);
        
        public abstract Task Send();
    }
}