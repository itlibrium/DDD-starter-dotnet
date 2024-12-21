using System.Transactions;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.TechnicalStuff.Outbox;

public class NonTransactionalMessageSendingDecorator<TCommand>(
    CommandHandler<TCommand> decorated,
    NonTransactionalOutboxes outboxes)
    : CommandHandler<TCommand>
    where TCommand : struct, Command
{
    public async Task Handle(TCommand command)
    {
        await decorated.Handle(command);
        var transaction = Transaction.Current;
        if (transaction != null && transaction.TransactionInformation.Status != TransactionStatus.Committed)
            throw new DesignError($"{GetType().Name} used within uncommitted transaction");
        await Task.WhenAll(outboxes.ForCurrentUseCase.Select(outbox => outbox.Send()));
    }
}
    
public class NonTransactionalMessageSendingDecorator<TCommand, TResult>(
    CommandHandler<TCommand, TResult> decorated,
    NonTransactionalOutboxes outboxes)
    : CommandHandler<TCommand, TResult>
    where TCommand : struct, Command
{
    public async Task<TResult> Handle(TCommand command)
    {
        var result = await decorated.Handle(command);
        var transaction = Transaction.Current;
        if (transaction != null && transaction.TransactionInformation.Status != TransactionStatus.Committed)
            throw new DesignError($"{GetType().Name} used within uncommitted transaction");
        await Task.WhenAll(outboxes.ForCurrentUseCase.Select(outbox => outbox.Send()));
        return result;
    }
}