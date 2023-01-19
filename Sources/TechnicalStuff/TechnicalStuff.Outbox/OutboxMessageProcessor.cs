using System.Threading;
using System.Threading.Tasks;

namespace MyCompany.Crm.TechnicalStuff.Outbox
{
    public interface OutboxMessageProcessor
    {
        string ProcessorType { get; }
        Task<MessageProcessingResult> Process(OutboxMessage outboxMessage, CancellationToken cancellationToken);
    }
}