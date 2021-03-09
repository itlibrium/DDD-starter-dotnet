using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace MyCompany.Crm.TechnicalStuff.Outbox.Postgres
{
    // TODO: deleting processed messages (using _settings.CleanupThreshold)
    [UsedImplicitly]
    public class TransactionalOutboxPostgresProcessor : TransactionalOutboxProcessor
    {
        private readonly Dictionary<string, OutboxMessagePublisher> _publishers;
        private readonly TransactionalOutboxPostgresProcessorSettings _processorSettings;

        protected TransactionalOutboxPostgresProcessor(IEnumerable<OutboxMessagePublisher> publishers,
            TransactionalOutboxPostgresProcessorSettings processorSettings)
        {
            _publishers = publishers.ToDictionary(p => p.SupportedMessageType);
            _processorSettings = processorSettings;
        }

        public async Task<OutboxProcessingResult> ProcessSingleBatch(CancellationToken cancellationToken)
        {
            var currentOffset = await GetCurrentOffset();
            var unprocessedMessages = await GetUnprocessedMessages(currentOffset, cancellationToken);
            if (unprocessedMessages.Count == 0)
                return OutboxProcessingResult.NoMessagesToProcess;
            
            foreach (var message in unprocessedMessages)
            {
                if (!_publishers.TryGetValue(message.Type, out var publisher))
                {
                    currentOffset++;
                    continue;
                    // TODO: logging (fatal because it's a design bug) and moving message to not processed
                }
                // TODO: store for poisoned messages
                await publisher.Publish(message, cancellationToken);
                currentOffset++;
                // TODO: configurable offset commit
            }
            await SaveCurrentOffset(currentOffset);
            return OutboxProcessingResult.BatchProcessed;
        }

        // TODO: SQL scripts (query and migration)
        private Task<long> GetCurrentOffset() => throw new NotImplementedException();

        private Task<IReadOnlyList<OutboxMessage>> GetUnprocessedMessages(long offset,
            CancellationToken cancellationToken) => throw new NotImplementedException();

        private Task SaveCurrentOffset(long offset) => throw new NotImplementedException();
    }
}