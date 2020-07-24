using System.Threading.Tasks;

namespace MyCompany.Crm.TechnicalStuff.UseCases.Messages
{
    public abstract class TransactionalOutbox
    {
        protected TransactionalOutbox(TransactionalOutboxes outboxes) => outboxes.Register(this);
        
        public abstract Task Save();
    }
}