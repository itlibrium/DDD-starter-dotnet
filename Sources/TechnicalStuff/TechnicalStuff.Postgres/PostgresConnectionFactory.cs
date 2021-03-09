using System.Data.Common;
using Npgsql;

namespace TechnicalStuff.Postgres
{
    public class PostgresConnectionFactory
    {
        private readonly string _connectionString;

        protected PostgresConnectionFactory(string connectionString) => _connectionString = connectionString;

        public DbConnection Create() => new NpgsqlConnection(_connectionString);
    }
}