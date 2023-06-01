using System;
using Npgsql;
using Polly;

namespace MyCompany.ECommerce.Nuke.Postgres
{
    public static class PostgresTasks
    {
        private static readonly Policy RetryPolicy = Policy
            .Handle<Exception>()
            .WaitAndRetry(3, attempt => TimeSpan.FromSeconds(attempt));

        public static void WaitForDatabase(string connectionString) => RetryPolicy.Execute(() =>
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
        });
    }
}