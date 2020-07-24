using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCompany.Crm.TechnicalStuff.Kafka.Outbox.Ef
{
    public class EfKafkaOutboxReader : KafkaOutboxReader
    {
        private readonly KafkaOutboxDbContext _dbContext;

        protected EfKafkaOutboxReader(KafkaOutboxDbContext dbContext) => _dbContext = dbContext;

        public IAsyncEnumerable<KafkaMessage> Read(string topic, long offset, int count)
        {
            throw new System.NotImplementedException();
        }

        public Task<long> GetCurrentOffset(string topic)
        {
            throw new System.NotImplementedException();
        }

        public Task CommitOffset(string topic, long offset)
        {
            throw new System.NotImplementedException();
        }
    }
}