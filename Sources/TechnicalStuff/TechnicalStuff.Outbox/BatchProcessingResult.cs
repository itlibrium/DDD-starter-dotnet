namespace MyCompany.ECommerce.TechnicalStuff.Outbox
{
    public enum BatchProcessingResult
    {
        NotFullBatchProcessed,
        FullBatchProcessed,
        TemporaryError
    }
}