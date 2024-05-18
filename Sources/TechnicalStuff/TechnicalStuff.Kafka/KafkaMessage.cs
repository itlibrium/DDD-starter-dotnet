namespace MyCompany.ECommerce.TechnicalStuff.Kafka;

public class KafkaMessage(string topic, string key, string valueAsJson)
{
    public string Topic { get; } = topic;
    public string Key { get; } = key;
    public string ValueAsJson { get; } = valueAsJson;
}