using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using TechnicalStuff.Postgres;

namespace MyCompany.Crm.TechnicalStuff.Outbox.Postgres
{
    [UsedImplicitly]
    public class TransactionalOutboxPostgresRepository<TConnectionFactory> : TransactionalOutboxRepository
        where TConnectionFactory : PostgresConnectionFactory
    {
        private readonly TConnectionFactory _connectionFactory;

        public TransactionalOutboxPostgresRepository(TConnectionFactory connectionFactory) =>
            _connectionFactory = connectionFactory;

        public Task Save(IEnumerable<OutboxMessage> messages)
        {
            throw new NotImplementedException();
        }
    }
}