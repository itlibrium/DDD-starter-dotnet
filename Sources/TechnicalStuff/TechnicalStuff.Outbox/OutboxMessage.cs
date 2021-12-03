using System;

namespace MyCompany.Crm.TechnicalStuff.Outbox
{
    public class OutboxMessage
    {
        public Guid Id { get; }
        public string PartitionKey { get; }
        public string ProcessorType { get; }
        public string MessageTypeId { get; }
        public string PayloadAsJson { get; }

        public OutboxMessage(Guid id, string partitionKey, string processorType, string messageTypeId,
            string payloadAsJson)
        {
            Id = id;
            PartitionKey = partitionKey;
            ProcessorType = processorType;
            MessageTypeId = messageTypeId;
            PayloadAsJson = payloadAsJson;
        }
    }
}