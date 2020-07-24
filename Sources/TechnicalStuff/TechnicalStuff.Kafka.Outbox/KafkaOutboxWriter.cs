using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCompany.Crm.TechnicalStuff.Kafka.Outbox
{
    public interface KafkaOutboxWriter
    {
        Task Write(KafkaMessage message);

        Task Write(IEnumerable<KafkaMessage> messages);
    }
}