using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;

namespace MyCompany.Crm.TechnicalStuff.Postgres
{
    // TODO: Upgrade to Npgsql 7.x when possible (now Marten is incompatible) and use NpgsqlDataSource
    //  https://www.npgsql.org/doc/basic-usage.html#connections
    public class PostgresConnectionProvider : IDisposable
    {
        private const string NoOpenTransaction =
            $"There are no open transaction for current connection - open it using {nameof(BeginTransaction)} method";
        
        private readonly string _connectionString;
        private NpgsqlConnection? _connection;
        private NpgsqlTransaction? _transaction;
        private List<NpgsqlConnection>? _oneOffConnections;

        protected PostgresConnectionProvider(string connectionString) => _connectionString = connectionString;

        public async Task<NpgsqlConnection> GetCurrentConnection()
        {
            if (_connection != null)
                return _connection;
            _connection = new NpgsqlConnection(_connectionString);
            await _connection.OpenAsync();
            return _connection;
        }

        public NpgsqlTransaction GetCurrentTransaction()
        {
            if (_transaction is null)
                throw new DesignError(NoOpenTransaction);
            return _transaction;
        }

        public async ValueTask<NpgsqlTransaction> BeginTransaction()
        {
            var connection = await GetCurrentConnection();
            var transaction = await connection.BeginTransactionAsync();
            return _transaction = transaction;
        }

        public async Task CommitTransaction()
        {
            if (_transaction is null)
                throw new DesignError(NoOpenTransaction);
            await _transaction.CommitAsync();
        }
        
        public async Task RollbackTransaction()
        {
            if (_transaction is null)
                throw new DesignError(NoOpenTransaction);
            await _transaction.RollbackAsync();
        }

        public NpgsqlConnection CreateOneOffConnection()
        {
            var connection = new NpgsqlConnection(_connectionString);
            _oneOffConnections ??= new List<NpgsqlConnection>();
            _oneOffConnections.Add(connection);
            return connection;
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
            if (_oneOffConnections is not null)
                foreach (var connection in _oneOffConnections)
                    connection.Dispose();
        }
    }
}