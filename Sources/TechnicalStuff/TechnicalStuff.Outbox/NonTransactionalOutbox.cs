using System.Threading.Tasks;

namespace MyCompany.ECommerce.TechnicalStuff.Outbox
{
    public abstract class NonTransactionalOutbox
    {
        protected NonTransactionalOutbox(NonTransactionalOutboxes outboxes) => outboxes.Register(this);
        
        public abstract Task Send();
    }
}