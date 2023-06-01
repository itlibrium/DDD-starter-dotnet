using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.TechnicalStuff.Outbox
{
    public class TransactionalMessageSendingDecorator<TCommand> : CommandHandler<TCommand>
        where TCommand : struct, Command
    {
        private readonly CommandHandler<TCommand> _decorated;
        private readonly TransactionalOutboxes _outboxes;

        public TransactionalMessageSendingDecorator(CommandHandler<TCommand> decorated, TransactionalOutboxes outboxes)
        {
            _decorated = decorated;
            _outboxes = outboxes;
        }

        public async Task Handle(TCommand command)
        {
            var transaction = Transaction.Current;
            if (transaction == null || transaction.TransactionInformation.Status != TransactionStatus.Active)
                throw new DesignError($"{GetType().Name} used without active transaction");
            await _decorated.Handle(command);
            await Task.WhenAll(_outboxes.ForCurrentUseCase.Select(outbox => outbox.Save()));
        }
    }
    
    public class TransactionalMessageSendingDecorator<TCommand, TResult> : CommandHandler<TCommand, TResult>
        where TCommand : struct, Command
    {
        private readonly CommandHandler<TCommand, TResult> _decorated;
        private readonly TransactionalOutboxes _outboxes;

        public TransactionalMessageSendingDecorator(CommandHandler<TCommand, TResult> decorated,
            TransactionalOutboxes outboxes)
        {
            _decorated = decorated;
            _outboxes = outboxes;
        }

        public async Task<TResult> Handle(TCommand command)
        {
            var transaction = Transaction.Current;
            if (transaction == null || transaction.TransactionInformation.Status != TransactionStatus.Active)
                throw new DesignError($"{GetType().Name} used without active transaction");
            var result = await _decorated.Handle(command);
            await Task.WhenAll(_outboxes.ForCurrentUseCase.Select(outbox => outbox.Save()));
            return result;
        }
    }
}