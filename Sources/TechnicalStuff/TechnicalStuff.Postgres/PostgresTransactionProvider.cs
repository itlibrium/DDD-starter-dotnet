using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MyCompany.ECommerce.TechnicalStuff.Persistence;
using Npgsql;

namespace MyCompany.ECommerce.TechnicalStuff.Postgres;

public class PostgresTransactionProvider : PostgresConnectionProvider, DbTransactionProvider
{
    private const string NoOpenTransaction =
        $"There are no open transaction - open it using {nameof(BeginTransaction)} method";

    private Stack<NpgsqlTransaction>? _transactions;

    protected PostgresTransactionProvider(string connectionString) : base(connectionString)
    {
    }

    public async Task BeginTransaction(IsolationLevel level = IsolationLevel.ReadCommitted)
    {
        var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();
        var transaction = await connection.BeginTransactionAsync(level);
        _transactions ??= new Stack<NpgsqlTransaction>();
        _transactions.Push(transaction);
    }

    public DbTransaction GetCurrentTransaction()
    {
        if (_transactions is null)
            throw new DesignError(NoOpenTransaction);
        var transaction = _transactions.Peek();
        if (transaction is null)
            throw new DesignError(NoOpenTransaction);
        return transaction;
    }

    public async Task CommitCurrentTransaction()
    {
        if (_transactions is null)
            throw new DesignError(NoOpenTransaction);
        var transaction = _transactions.Pop();
        if (transaction is null)
            throw new DesignError(NoOpenTransaction);
        await transaction.CommitAsync();
        await transaction.DisposeAsync();
        await transaction.Connection!.DisposeAsync();
    }
        
    public async Task RollbackCurrentTransaction()
    {
        if (_transactions is null)
            throw new DesignError(NoOpenTransaction);
        var transaction = _transactions.Pop();
        if (transaction is null)
            throw new DesignError(NoOpenTransaction);
        await transaction.RollbackAsync();
        await transaction.DisposeAsync();
        await transaction.Connection!.DisposeAsync();
    }
        
    public void Dispose()
    {
        base.Dispose();
        if (_transactions is not null)
            foreach (var transaction in _transactions)
                transaction.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await base.DisposeAsync();
        if (_transactions is not null)
            foreach (var transaction in _transactions)
                await transaction.DisposeAsync();
    }
}