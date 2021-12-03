using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyCompany.Crm.Sales;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.ProcessModel;

namespace MyCompany.Crm.Infrastructure
{
    public class FakeMessageConsumer : BackgroundService
    {
        private readonly FakeMessageBroker _broker;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<FakeMessageConsumer> _logger;

        public FakeMessageConsumer(FakeMessageBroker broker, IServiceScopeFactory scopeFactory,
            ILogger<FakeMessageConsumer> logger)
        {
            _broker = broker;
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken) => Task.WhenAll(
            ConsumeCommand(stoppingToken),
            ConsumeEvent(stoppingToken));

        private async Task ConsumeCommand(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var command = await _broker.ReadCommand(cancellationToken);
                _logger.LogDebug("Handling command started. Command type: {CommandType}", command.GetType().Name);
                using var scope = _scopeFactory.CreateScope();
                var handler = (MessageHandler) scope.ServiceProvider.GetService(CreateCommandHandlerTypeFor(command));
                try
                {
                    await handler.Handle(command);
                }
                catch (DomainError e)
                {
                    _logger.LogError(e, "Domain error");
                }
                _logger.LogDebug("Handling command finished. Command type: {CommandType}", command.GetType().Name);
            }
        }

        private static Type CreateCommandHandlerTypeFor(Command command) =>
            typeof(CommandHandler<>).MakeGenericType(command.GetType());

        private async Task ConsumeEvent(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var domainEvent = await _broker.ReadEvent(cancellationToken);
                _logger.LogDebug("Handling event started. Command type: {EventType}", domainEvent.GetType().Name);
                using var scope = _scopeFactory.CreateScope();
                var handler =
                    (MessageHandler) scope.ServiceProvider.GetService(CreateEventHandlerTypeFor(domainEvent));
                try
                {
                    await handler.Handle(domainEvent);
                }
                catch (DomainError e)
                {
                    _logger.LogError(e, "Domain error");
                }
                _logger.LogDebug("Handling event finished. Command type: {EventType}", domainEvent.GetType().Name);
            }
        }

        private static Type CreateEventHandlerTypeFor(DomainEvent domainEvent) =>
            typeof(DomainEventHandler<>).MakeGenericType(domainEvent.GetType());
    }
}