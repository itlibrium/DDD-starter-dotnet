namespace MyCompany.ECommerce.TechnicalStuff.Outbox;

public interface TransactionalOutboxProcessor
{
    Task<BatchProcessingResult> ProcessSingleBatch(int partition, CancellationToken cancellationToken);
}