﻿using JetBrains.Annotations;
using MyCompany.ECommerce.TechnicalStuff.Persistence;

namespace MyCompany.ECommerce.TechnicalStuff.Outbox.Postgres;

[UsedImplicitly]
public class PostgresOutboxRepository(MainDb db) : TransactionalOutboxRepository
{
    private readonly MainDb _db = db;

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