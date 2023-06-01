using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MyCompany.ECommerce.TechnicalStuff.Outbox;
using Quartz;

namespace TechnicalStuff.Outbox.Quartz
{
    // TODO: deleting processed messages in separate Job
    [DisallowConcurrentExecution]
    public class OutboxJob<TProcessor> : IJob
        where TProcessor : class, TransactionalOutboxProcessor
    {
        private readonly int _partition;
        private readonly TProcessor _processor;
        private readonly ILogger<OutboxJob<TProcessor>> _logger;

        public OutboxJob(int partition, TProcessor processor, ILogger<OutboxJob<TProcessor>> logger)
        {
            _partition = partition;
            _processor = processor;
            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                _logger.LogDebug("Outbox processing started. {OutboxProcessorType}, {Partition}",
                    _processor.GetType().Name, _partition);
                while (!context.CancellationToken.IsCancellationRequested)
                {
                    var processingResult = await _processor.ProcessSingleBatch(_partition, context.CancellationToken);
                    switch (processingResult)
                    {
                        case BatchProcessingResult.FullBatchProcessed:
                            break;
                        case BatchProcessingResult.NotFullBatchProcessed:
                        case BatchProcessingResult.TemporaryError:
                            return;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(processingResult));
                    }
                }
                _logger.LogDebug("Outbox processing ended. {OutboxProcessorType}, {Partition}",
                    _processor.GetType().Name, _partition);
            }
            catch (Exception e) when (e is not OperationCanceledException)
            {
                _logger.LogCritical(e,
                    "Unexpected exception in outbox processor: {OutboxProcessorType}",
                    _processor.GetType().Name);
            }
        }
    }
}