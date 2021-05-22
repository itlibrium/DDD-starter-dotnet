using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCompany.Crm.Sales;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Infrastructure
{
    public class FakeMessageConsumer : BackgroundService
    {
        private readonly FakeMessageBroker _broker;
        private readonly IServiceScopeFactory _scopeFactory;

        public FakeMessageConsumer(FakeMessageBroker broker, IServiceScopeFactory scopeFactory)
        {
            _broker = broker;
            _scopeFactory = scopeFactory;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken) => Task.WhenAll(
            ConsumeCommand(stoppingToken),
            ConsumeEvent(stoppingToken));

        private async Task ConsumeCommand(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var command = await _broker.ReadCommand(cancellationToken);
                using var scope = _scopeFactory.CreateScope();
                var handler = (CommandHandler) scope.ServiceProvider.GetService(CreateCommandHandlerTypeFor(command));
                await handler.Handle(command);
            }
        }

        private static Type CreateCommandHandlerTypeFor(Command command) =>
            typeof(CommandHandler<>).MakeGenericType(command.GetType());

        private async Task ConsumeEvent(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var domainEvent = await _broker.ReadEvent(cancellationToken);
                using var scope = _scopeFactory.CreateScope();
                var handler =
                    (DomainEventHandler) scope.ServiceProvider.GetService(CreateEventHandlerTypeFor(domainEvent));
                await handler.Handle(domainEvent);
            }
        }

        private static Type CreateEventHandlerTypeFor(DomainEvent domainEvent) =>
            typeof(DomainEventHandler<>).MakeGenericType(domainEvent.GetType());
    }
}