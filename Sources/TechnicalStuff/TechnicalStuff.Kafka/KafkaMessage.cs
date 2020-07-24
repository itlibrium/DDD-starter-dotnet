namespace MyCompany.Crm.TechnicalStuff.Kafka
{
    public class KafkaMessage
    {
        public string Topic { get; }
        public string Key { get; }
        public string Value { get; }
        
        public KafkaMessage(string topic, string key, string value)
        {
            Topic = topic;
            Key = key;
            Value = value;
        }
    }
}