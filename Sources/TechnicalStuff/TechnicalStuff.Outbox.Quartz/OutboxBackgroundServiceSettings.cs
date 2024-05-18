using System;
using System.Collections.Generic;

namespace MyCompany.ECommerce.TechnicalStuff.Outbox.Quartz;

public class OutboxBackgroundServiceSettings(
    IReadOnlyList<Type> processorTypes,
    int? minDelayBetweenBatches,
    int? delayAfterEmptyBatch)
{
    public IReadOnlyList<Type> ProcessorTypes { get; } = processorTypes;
    public int? MinDelayBetweenBatches { get; } = minDelayBetweenBatches;
    public int? DelayAfterEmptyBatch { get; } = delayAfterEmptyBatch;
}