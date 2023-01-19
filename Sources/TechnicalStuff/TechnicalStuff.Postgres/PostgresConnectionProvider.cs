using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using MyCompany.Crm.TechnicalStuff.Persistence;
using Npgsql;

namespace MyCompany.Crm.TechnicalStuff.Postgres
{
    // TODO: Upgrade to Npgsql 7.x when possible (now Marten is incompatible) and use NpgsqlDataSource
    //  https://www.npgsql.org/doc/basic-usage.html#connections
    public class PostgresConnectionProvider : DbConnectionProvider, IDisposable, IAsyncDisposable
    {
        protected readonly string _connectionString;
        private List<NpgsqlConnection>? _oneOffConnections;

        protected PostgresConnectionProvider(string connectionString) => _connectionString = connectionString;

        public async Task<DbConnection> CreateOneOffConnection()
        {
            var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();
            _oneOffConnections ??= new List<NpgsqlConnection>();
            _oneOffConnections.Add(connection);
            return connection;
        }

        public void Dispose()
        {
            if (_oneOffConnections is not null)
                foreach (var connection in _oneOffConnections)
                    connection.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            if (_oneOffConnections is not null)
                foreach (var connection in _oneOffConnections)
                    await connection.DisposeAsync();
        }
    }
}