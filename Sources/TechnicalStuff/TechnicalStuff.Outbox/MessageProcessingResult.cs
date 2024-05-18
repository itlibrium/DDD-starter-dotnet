namespace MyCompany.ECommerce.TechnicalStuff.Outbox;

public enum MessageProcessingResult
{
    Processed,
    TemporaryError,
    MessageUnprocessable
}