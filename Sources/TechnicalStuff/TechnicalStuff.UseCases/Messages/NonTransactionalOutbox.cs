using System.Threading.Tasks;

namespace MyCompany.Crm.TechnicalStuff.UseCases.Messages
{
    public abstract class NonTransactionalOutbox
    {
        protected NonTransactionalOutbox(NonTransactionalOutboxes outboxes) => outboxes.Register(this);
        
        public abstract Task Send();
    }
}