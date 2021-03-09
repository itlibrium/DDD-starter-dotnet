using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCompany.Crm.TechnicalStuff.Outbox;

namespace BackgroundServices.Outboxes
{
    public class OutboxBackgroundService : BackgroundService
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly TimeSpan _minDelayBetweenBatches;
        private readonly TimeSpan _delayAfterEmptyBatch;
        private readonly IReadOnlyList<Type> _processorTypes;
        
        public OutboxBackgroundService(IServiceScopeFactory serviceScopeFactory,
            OutboxBackgroundServiceSettings settings)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _minDelayBetweenBatches = settings.MinDelayBetweenBatches.HasValue 
                ? TimeSpan.FromMilliseconds(settings.MinDelayBetweenBatches.Value)
                : TimeSpan.Zero;
            _delayAfterEmptyBatch = settings.DelayAfterEmptyBatch.HasValue ?
                TimeSpan.FromMilliseconds(settings.DelayAfterEmptyBatch.Value)
                : _minDelayBetweenBatches;
            _processorTypes = settings.ProcessorTypes;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken) =>
            Task.WhenAll(_processorTypes.Select(t => Execute(t, stoppingToken)));

        // TODO: logging
        private async Task Execute(Type processorType, CancellationToken stoppingToken)
        {
            while (true)
            {
                stoppingToken.ThrowIfCancellationRequested();
                using var scope = _serviceScopeFactory.CreateScope();
                var processor = (TransactionalOutboxProcessor) scope.ServiceProvider.GetService(processorType);
                try
                {
                    _stopwatch.Restart();
                    var processingResult = await processor.ProcessSingleBatch(stoppingToken);
                    _stopwatch.Stop();
                    var processingTime = _stopwatch.Elapsed;
                    await Delay(processingResult, processingTime, stoppingToken);
                }
                catch (OperationCanceledException e) when (e.CancellationToken == stoppingToken)
                {
                    throw;
                }
                catch (Exception e)
                {
                    return;
                }
            }
        }

        private async Task Delay(OutboxProcessingResult processingResult, TimeSpan processingTime,
            CancellationToken stoppingToken)
        {
            var delay = processingResult switch
            {
                OutboxProcessingResult.BatchProcessed => _minDelayBetweenBatches - processingTime,
                OutboxProcessingResult.NoMessagesToProcess => _delayAfterEmptyBatch - processingTime,
                _ => throw new ArgumentOutOfRangeException(nameof(processingResult), processingResult,
                    $"Unsupported {nameof(OutboxProcessingResult)}")
            };
            if (delay > TimeSpan.Zero)
                await Task.Delay(delay, stoppingToken);
        }
    }
}