using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using TechnicalStuff.Postgres;

namespace MyCompany.Crm.TechnicalStuff.Outbox.Postgres
{
    [UsedImplicitly]
    public class PostgresOutboxRepository<TConnectionFactory> : TransactionalOutboxRepository
        where TConnectionFactory : PostgresConnectionFactory
    {
        private readonly TConnectionFactory _connectionFactory;

        public PostgresOutboxRepository(TConnectionFactory connectionFactory) =>
            _connectionFactory = connectionFactory;

        public Task Save(IEnumerable<OutboxMessage> messages)
        {
            throw new NotImplementedException();
        }

        public async Task<Batch> GetUnprocessedMessagesFor(int partition, int batchSize,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task SaveCurrentOffset(int partition, long currentOffset)
        {
            throw new NotImplementedException();
        }

        public async Task MoveToUnprocessableMessages(OutboxMessage message)
        {
            throw new NotImplementedException();
        }
    }
}