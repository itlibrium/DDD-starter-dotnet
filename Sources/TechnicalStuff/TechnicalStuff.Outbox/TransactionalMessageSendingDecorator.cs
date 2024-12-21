using System.Transactions;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.TechnicalStuff.Outbox;

public class TransactionalMessageSendingDecorator<TCommand>(
    CommandHandler<TCommand> decorated,
    TransactionalOutboxes outboxes)
    : CommandHandler<TCommand>
    where TCommand : struct, Command
{
    public async Task Handle(TCommand command)
    {
        var transaction = Transaction.Current;
        if (transaction == null || transaction.TransactionInformation.Status != TransactionStatus.Active)
            throw new DesignError($"{GetType().Name} used without active transaction");
        await decorated.Handle(command);
        await Task.WhenAll(outboxes.ForCurrentUseCase.Select(outbox => outbox.Save()));
    }
}
    
public class TransactionalMessageSendingDecorator<TCommand, TResult>(
    CommandHandler<TCommand, TResult> decorated,
    TransactionalOutboxes outboxes)
    : CommandHandler<TCommand, TResult>
    where TCommand : struct, Command
{
    public async Task<TResult> Handle(TCommand command)
    {
        var transaction = Transaction.Current;
        if (transaction == null || transaction.TransactionInformation.Status != TransactionStatus.Active)
            throw new DesignError($"{GetType().Name} used without active transaction");
        var result = await decorated.Handle(command);
        await Task.WhenAll(outboxes.ForCurrentUseCase.Select(outbox => outbox.Save()));
        return result;
    }
}