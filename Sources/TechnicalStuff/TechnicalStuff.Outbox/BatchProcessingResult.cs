namespace MyCompany.Crm.TechnicalStuff.Outbox
{
    public enum BatchProcessingResult
    {
        NotFullBatchProcessed,
        FullBatchProcessed,
        TemporaryError
    }
}