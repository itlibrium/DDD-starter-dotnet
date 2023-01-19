using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MyCompany.Crm.TechnicalStuff.Persistence;

namespace MyCompany.Crm.TechnicalStuff.Outbox.Postgres
{
    [UsedImplicitly]
    public class PostgresOutboxRepository : TransactionalOutboxRepository
    {
        private readonly MainDb _db;

        public PostgresOutboxRepository(MainDb db) => _db = db;

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