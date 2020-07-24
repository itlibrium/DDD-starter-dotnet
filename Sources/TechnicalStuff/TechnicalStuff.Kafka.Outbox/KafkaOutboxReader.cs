using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCompany.Crm.TechnicalStuff.Kafka.Outbox
{
    public interface KafkaOutboxReader
    {
        IAsyncEnumerable<KafkaMessage> Read(string topic, long offset, int count);
        Task<long> GetCurrentOffset(string topic);
        Task CommitOffset(string topic, long offset);
    }
}