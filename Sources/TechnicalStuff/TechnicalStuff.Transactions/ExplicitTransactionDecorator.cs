using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MyCompany.ECommerce.TechnicalStuff.Persistence;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.TechnicalStuff.Transactions;

[PublicAPI]
public class ExplicitTransactionDecorator<TCommand> : CommandHandler<TCommand>
    where TCommand : struct, Command
{
    private readonly CommandHandler<TCommand> _decorated;
    private readonly MainDb _db;

    public ExplicitTransactionDecorator(CommandHandler<TCommand> decorated, MainDb db)
    {
        _decorated = decorated;
        _db = db;
    }

    public async Task Handle(TCommand command)
    {
        await _db.BeginTransaction();
        try
        {
            await _decorated.Handle(command);
            await _db.CommitCurrentTransaction();
        }
        catch (Exception)
        {
            await _db.RollbackCurrentTransaction();
            throw;
        }
    }
}

[PublicAPI]
public class ExplicitTransactionDecorator<TCommand, TResult> : CommandHandler<TCommand, TResult>
    where TCommand : struct, Command
{
    private readonly CommandHandler<TCommand, TResult> _decorated;
    private readonly MainDb _db;

    public ExplicitTransactionDecorator(CommandHandler<TCommand, TResult> decorated, MainDb db)
    {
        _decorated = decorated;
        _db = db;
    }

    public async Task<TResult> Handle(TCommand command)
    {
        await _db.BeginTransaction();
        try
        {
            var result = await _decorated.Handle(command);
            await _db.CommitCurrentTransaction();
            return result;
        }
        catch (Exception)
        {
            await _db.RollbackCurrentTransaction();
            throw;
        }
    }
}