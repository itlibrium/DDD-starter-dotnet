using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.TechnicalStuff.Outbox
{
    public class NonTransactionalMessageSendingDecorator<TCommand> : CommandHandler<TCommand>
        where TCommand : struct, Command
    {
        private readonly CommandHandler<TCommand> _decorated;
        private readonly NonTransactionalOutboxes _outboxes;

        public NonTransactionalMessageSendingDecorator(CommandHandler<TCommand> decorated,
            NonTransactionalOutboxes outboxes)
        {
            _decorated = decorated;
            _outboxes = outboxes;
        }

        public async Task Handle(TCommand command)
        {
            await _decorated.Handle(command);
            var transaction = Transaction.Current;
            if (transaction != null && transaction.TransactionInformation.Status != TransactionStatus.Committed)
                throw new InvalidOperationException();
            await Task.WhenAll(_outboxes.ForCurrentUseCase.Select(outbox => outbox.Send()));
        }
    }
    
    public class NonTransactionalMessageSendingDecorator<TCommand, TResult> : CommandHandler<TCommand, TResult>
        where TCommand : struct, Command
    {
        private readonly CommandHandler<TCommand, TResult> _decorated;
        private readonly NonTransactionalOutboxes _outboxes;

        public NonTransactionalMessageSendingDecorator(CommandHandler<TCommand, TResult> decorated,
            NonTransactionalOutboxes outboxes)
        {
            _decorated = decorated;
            _outboxes = outboxes;
        }

        public async Task<TResult> Handle(TCommand command)
        {
            var result = await _decorated.Handle(command);
            var transaction = Transaction.Current;
            if (transaction != null && transaction.TransactionInformation.Status != TransactionStatus.Committed)
                throw new InvalidOperationException();
            await Task.WhenAll(_outboxes.ForCurrentUseCase.Select(outbox => outbox.Send()));
            return result;
        }
    }
}