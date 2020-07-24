using System.Diagnostics.CodeAnalysis;
using MyCompany.Crm.TechnicalStuff.Kafka.Outbox.Ef;

namespace MyCompany.Crm.Sales
{
    public class SalesKafkaOutboxWriter : EfKafkaOutboxWriter
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter", Justification = "DI registration")]
        public SalesKafkaOutboxWriter(SalesKafkaOutboxDbContext dbContext) : base(dbContext) { }
    }
}