using System.Threading;
using System.Threading.Tasks;

namespace MyCompany.Crm.TechnicalStuff.Outbox
{
    public interface OutboxMessagePublisher
    {
        string SupportedMessageType { get; }
        Task Publish(OutboxMessage message, CancellationToken cancellationToken);
    }
}