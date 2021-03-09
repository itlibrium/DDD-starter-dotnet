namespace MyCompany.Crm.TechnicalStuff.Kafka
{
    public class KafkaMessage
    {
        public const string MessageType = "KafkaMessage";
        
        public string Topic { get; }
        public string Key { get; }
        public string ValueAsJson { get; }
        
        public KafkaMessage(string topic, string key, string valueAsJson)
        {
            Topic = topic;
            Key = key;
            ValueAsJson = valueAsJson;
        }
    }
}