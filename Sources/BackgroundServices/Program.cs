using BackgroundServices.Outboxes;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCompany.Crm.TechnicalStuff.Kafka;
using MyCompany.Crm.TechnicalStuff.Outbox;
using MyCompany.Crm.TechnicalStuff.Outbox.Kafka;
using MyCompany.Crm.TechnicalStuff.Outbox.Postgres;

namespace BackgroundServices
{
    public static class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        private static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<OutboxBackgroundService>();
                services.AddSingleton(hostContext.Configuration
                    .GetSection("TransactionalOutboxPostgresProcessor")
                    .Get<TransactionalOutboxPostgresProcessorSettings>());
                services.AddSingleton(hostContext.Configuration
                    .GetSection("OutboxBackgroundService")
                    .Get<OutboxBackgroundServiceSettings>());
                services.AddScoped<TransactionalOutboxPostgresProcessor>();
                // TODO: production ready producer config
                services.AddSingleton(new KafkaMessageProducer(
                    new ProducerConfig()));
                services.AddScoped<OutboxMessagePublisher, OutboxMessageKafkaPublisher>();
            });
    }
}