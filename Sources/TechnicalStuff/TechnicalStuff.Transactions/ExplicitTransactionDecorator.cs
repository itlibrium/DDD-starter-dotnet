using JetBrains.Annotations;
using MyCompany.ECommerce.TechnicalStuff.Persistence;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.TechnicalStuff.Transactions;

[PublicAPI]
public class ExplicitTransactionDecorator<TCommand>(CommandHandler<TCommand> decorated, MainDb db)
    : CommandHandler<TCommand>
    where TCommand : struct, Command
{
    public async Task Handle(TCommand command)
    {
        await db.BeginTransaction();
        try
        {
            await decorated.Handle(command);
            await db.CommitCurrentTransaction();
        }
        catch (Exception)
        {
            await db.RollbackCurrentTransaction();
            throw;
        }
    }
}

[PublicAPI]
public class ExplicitTransactionDecorator<TCommand, TResult>(CommandHandler<TCommand, TResult> decorated, MainDb db)
    : CommandHandler<TCommand, TResult>
    where TCommand : struct, Command
{
    public async Task<TResult> Handle(TCommand command)
    {
        await db.BeginTransaction();
        try
        {
            var result = await decorated.Handle(command);
            await db.CommitCurrentTransaction();
            return result;
        }
        catch (Exception)
        {
            await db.RollbackCurrentTransaction();
            throw;
        }
    }
}