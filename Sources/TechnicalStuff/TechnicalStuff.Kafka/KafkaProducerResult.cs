namespace MyCompany.ECommerce.TechnicalStuff.Kafka;

public enum KafkaProducerResult
{
    NoError,
    InvalidMessage,
    NoAck,
    OtherError
}