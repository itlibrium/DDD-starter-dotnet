using System;
using System.Collections.Generic;

namespace TechnicalStuff.Outbox.Quartz
{
    public class OutboxBackgroundServiceSettings
    {
        public IReadOnlyList<Type> ProcessorTypes { get; }
        public int? MinDelayBetweenBatches { get; }
        public int? DelayAfterEmptyBatch { get; }

        public OutboxBackgroundServiceSettings(IReadOnlyList<Type> processorTypes, int? minDelayBetweenBatches,
            int? delayAfterEmptyBatch)
        {
            ProcessorTypes = processorTypes;
            MinDelayBetweenBatches = minDelayBetweenBatches;
            DelayAfterEmptyBatch = delayAfterEmptyBatch;
        }
    }
}