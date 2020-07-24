using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCompany.Crm.TechnicalStuff.Kafka.Outbox.Ef
{
    public class EfKafkaOutboxWriter : KafkaOutboxWriter
    {
        private readonly KafkaOutboxDbContext _dbContext;
        
        public EfKafkaOutboxWriter(KafkaOutboxDbContext dbContext) => _dbContext = dbContext;

        public Task Write(KafkaMessage message)
        {
            throw new System.NotImplementedException();
        }

        public Task Write(IEnumerable<KafkaMessage> messages)
        {
            throw new System.NotImplementedException();
        }
    }
}