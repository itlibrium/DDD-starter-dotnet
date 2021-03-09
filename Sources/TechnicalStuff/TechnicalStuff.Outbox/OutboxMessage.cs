using System;

namespace MyCompany.Crm.TechnicalStuff.Outbox
{
    public class OutboxMessage
    {
        public Guid Id { get; }
        public string Type { get; }
        public string PayloadAsJson { get; }

        public OutboxMessage(Guid id, string type, string payloadAsJson)
        {
            Id = id;
            Type = type;
            PayloadAsJson = payloadAsJson;
        }
    }
}