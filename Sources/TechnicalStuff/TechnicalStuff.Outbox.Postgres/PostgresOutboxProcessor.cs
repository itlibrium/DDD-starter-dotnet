using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using TechnicalStuff.Postgres;

namespace MyCompany.Crm.TechnicalStuff.Outbox.Postgres
{
    [UsedImplicitly]
    public class PostgresOutboxProcessor<TConnectionFactory> : TransactionalOutboxProcessor
        where TConnectionFactory : PostgresConnectionFactory
    {
        private readonly PostgresOutboxRepository<TConnectionFactory> _repository;
        private readonly Dictionary<string, OutboxMessageProcessor> _processors;
        private readonly PostgresOutboxProcessorSettings _processorSettings;
        private readonly ILogger<PostgresOutboxProcessor<TConnectionFactory>> _logger;

        protected PostgresOutboxProcessor(
            PostgresOutboxRepository<TConnectionFactory> repository,
            IEnumerable<OutboxMessageProcessor> messageProcessors,
            PostgresOutboxProcessorSettings processorSettings,
            ILogger<PostgresOutboxProcessor<TConnectionFactory>> logger)
        {
            _repository = repository;
            _processors = messageProcessors.ToDictionary(p => p.ProcessorType);
            _processorSettings = processorSettings;
            _logger = logger;
        }

        public async Task<BatchProcessingResult> ProcessSingleBatch(int partition, CancellationToken cancellationToken)
        {
            try
            {
                var batch = await _repository.GetUnprocessedMessagesFor(partition, _processorSettings.BatchSize,
                    cancellationToken);
                foreach (var item in batch)
                {
                    var result = await Process(item, cancellationToken);
                    if (result == BatchItemProcessingResult.TemporaryError)
                    {
                        await _repository.SaveCurrentOffset(partition, item.Offset - 1);
                        return BatchProcessingResult.TemporaryError;
                    }
                    if (batch.IsOffsetCommitRequiredFor(item, _processorSettings.CommitOffsetInterval))
                        await _repository.SaveCurrentOffset(partition, item.Offset);
                }
                return batch.IsFull
                    ? BatchProcessingResult.FullBatchProcessed
                    : BatchProcessingResult.NotFullBatchProcessed;
            }
            catch (TemporaryInfrastructureError e)
            {
                _logger.LogError(e, "Temporary infrastructure error");
                return BatchProcessingResult.TemporaryError;
            }
        }

        private async Task<BatchItemProcessingResult> Process(Batch.Item item, CancellationToken cancellationToken)
        {
            var messageProcessingResult = await Process(item.OutboxMessage, cancellationToken);
            switch (messageProcessingResult)
            {
                case MessageProcessingResult.Processed:
                    return BatchItemProcessingResult.Processed;
                case MessageProcessingResult.MessageUnprocessable:
                    await _repository.MoveToUnprocessableMessages(item.OutboxMessage);
                    return BatchItemProcessingResult.Processed;
                case MessageProcessingResult.TemporaryError:
                    return BatchItemProcessingResult.TemporaryError;
                default:
                    throw new ArgumentOutOfRangeException(nameof(messageProcessingResult));
            }
        }

        private async Task<MessageProcessingResult> Process(OutboxMessage message, CancellationToken cancellationToken)
        {
            if (_processors.TryGetValue(message.ProcessorType, out var processor))
                return await processor.Process(message, cancellationToken);
            _logger.LogCritical("Missing OutboxMessageProcessor of type: {ProcessorType}", message.ProcessorType);
            return MessageProcessingResult.MessageUnprocessable;
        }

        private enum BatchItemProcessingResult
        {
            Processed,
            TemporaryError
        }
    }
}