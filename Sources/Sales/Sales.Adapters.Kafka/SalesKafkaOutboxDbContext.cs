using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MyCompany.Crm.TechnicalStuff.Kafka.Outbox.Ef;

namespace MyCompany.Crm.Sales
{
    public class SalesKafkaOutboxDbContext : KafkaOutboxDbContext
    {
        protected SalesKafkaOutboxDbContext([NotNull] DbContextOptions<SalesKafkaOutboxDbContext> options) :
            base(options) { }
    }
}