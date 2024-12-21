using MyCompany.ECommerce.Sales;
using MyCompany.ECommerce.TechnicalStuff;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Infrastructure;

public class FakeMessageConsumer(
    FakeMessageBroker broker,
    IServiceScopeFactory scopeFactory,
    ILogger<FakeMessageConsumer> logger)
    : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken) => Task.WhenAll(
        ConsumeCommand(stoppingToken),
        ConsumeEvent(stoppingToken));

    private async Task ConsumeCommand(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var command = await broker.ReadCommand(cancellationToken);
            logger.LogDebug("Handling command started. Command type: {CommandType}", command.GetType().Name);
            using var scope = scopeFactory.CreateScope();
            var handler = (MessageHandler) scope.ServiceProvider.GetService(CreateCommandHandlerTypeFor(command));
            try
            {
                await handler.Handle(command);
            }
            catch (DomainError e)
            {
                logger.LogError(e, "Domain error");
            }
            logger.LogDebug("Handling command finished. Command type: {CommandType}", command.GetType().Name);
        }
    }

    private static Type CreateCommandHandlerTypeFor(Command command) =>
        typeof(CommandHandler<>).MakeGenericType(command.GetType());

    private async Task ConsumeEvent(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var domainEvent = await broker.ReadEvent(cancellationToken);
            logger.LogDebug("Handling event started. Command type: {EventType}", domainEvent.GetType().Name);
            using var scope = scopeFactory.CreateScope();
            var handler =
                (MessageHandler) scope.ServiceProvider.GetService(CreateEventHandlerTypeFor(domainEvent));
            try
            {
                await handler.Handle(domainEvent);
            }
            catch (DomainError e)
            {
                logger.LogError(e, "Domain error");
            }
            logger.LogDebug("Handling event finished. Command type: {EventType}", domainEvent.GetType().Name);
        }
    }

    private static Type CreateEventHandlerTypeFor(DomainEvent domainEvent) =>
        typeof(DomainEventHandler<>).MakeGenericType(domainEvent.GetType());
}