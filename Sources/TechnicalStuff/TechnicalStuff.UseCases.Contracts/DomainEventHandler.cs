using System.Threading.Tasks;

namespace MyCompany.Crm.TechnicalStuff.UseCases
{
    public interface DomainEventHandler
    {
        Task Handle(DomainEvent domainEvent);
    }

    public interface DomainEventHandler<in TEvent> : DomainEventHandler
        where TEvent : DomainEvent
    {
        Task DomainEventHandler.Handle(DomainEvent domainEvent) => Handle((TEvent) domainEvent);

        Task Handle(TEvent domainEvent);
    }
}