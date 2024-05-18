using Confluent.Kafka;
using MyCompany.ECommerce.TechnicalStuff.Kafka;

namespace MyCompany.ECommerce.DI;

public static class Kafka
{
    public static IServiceCollection AddKafka(this IServiceCollection services, IConfiguration configuration)
    {
        var producerConfig = configuration.GetSection("KafkaProducer").Get<ProducerConfig>();
        services.AddSingleton(producerConfig);
        services.AddSingleton<KafkaMessageProducer>();
        return services;
    }
}