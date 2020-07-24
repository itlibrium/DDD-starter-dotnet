using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCompany.Crm.TechnicalStuff.Kafka;

namespace MyCompany.Crm.DI
{
    public static class Kafka
    {
        public static IServiceCollection AddKafka(this IServiceCollection services, IConfiguration configuration)
        {
            var producerConfig = configuration.GetSection("KafkaProducer").Get<ProducerConfig>();
            services.AddSingleton(producerConfig);
            services.AddSingleton<KafkaProducer>();
            return services;
        }
    }
}