using System.Transactions;
using JetBrains.Annotations;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.TechnicalStuff.Transactions;

[PublicAPI]
public class AmbientTransactionDecorator<TCommand>(CommandHandler<TCommand> decorated) : CommandHandler<TCommand>
    where TCommand : struct, Command
{
    public async Task Handle(TCommand command)
    {
        using var scope = new TransactionScope(
            TransactionScopeOption.RequiresNew,
            new TransactionOptions {IsolationLevel = IsolationLevel.ReadCommitted},
            TransactionScopeAsyncFlowOption.Enabled);
        await decorated.Handle(command);
        scope.Complete();
    }
}
    
[PublicAPI]
public class AmbientTransactionDecorator<TCommand, TResult>(CommandHandler<TCommand, TResult> decorated)
    : CommandHandler<TCommand, TResult>
    where TCommand : struct, Command
{
    public async Task<TResult> Handle(TCommand command)
    {
        using var scope = new TransactionScope(
            TransactionScopeOption.RequiresNew,
            new TransactionOptions {IsolationLevel = IsolationLevel.ReadCommitted},
            TransactionScopeAsyncFlowOption.Enabled);
        var result = await decorated.Handle(command);
        scope.Complete();
        return result;
    }
}