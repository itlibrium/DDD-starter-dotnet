using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace MyCompany.Crm.TechnicalStuff.Kafka.Outbox.Ef
{
    public class KafkaOutboxDbContext : DbContext
    {
        protected KafkaOutboxDbContext([NotNull] DbContextOptions options) : base(options) { }
    }
}