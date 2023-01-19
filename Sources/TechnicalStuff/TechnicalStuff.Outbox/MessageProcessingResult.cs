namespace MyCompany.Crm.TechnicalStuff.Outbox
{
    public enum MessageProcessingResult
    {
        Processed,
        TemporaryError,
        MessageUnprocessable
    }
}