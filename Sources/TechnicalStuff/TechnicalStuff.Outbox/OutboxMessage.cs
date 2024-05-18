namespace MyCompany.ECommerce.TechnicalStuff.Outbox;

public class OutboxMessage(
    Guid id,
    string partitionKey,
    string processorType,
    string messageTypeId,
    string payloadAsJson)
{
    public Guid Id { get; } = id;
    public string PartitionKey { get; } = partitionKey;
    public string ProcessorType { get; } = processorType;
    public string MessageTypeId { get; } = messageTypeId;
    public string PayloadAsJson { get; } = payloadAsJson;
}