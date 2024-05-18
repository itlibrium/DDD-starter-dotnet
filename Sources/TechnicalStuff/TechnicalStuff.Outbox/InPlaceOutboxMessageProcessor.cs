using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using Newtonsoft.Json;

namespace MyCompany.ECommerce.TechnicalStuff.Outbox;

public class InPlaceOutboxMessageProcessor(
    MessageTypes messageTypes,
    IServiceScopeFactory serviceScopeProvider,
    ILogger<InPlaceOutboxMessageProcessor> logger)
    : OutboxMessageProcessor
{
    public string ProcessorType => OutboxMessageProcessors.InPlace;

    public async Task<MessageProcessingResult> Process(OutboxMessage outboxMessage,
        CancellationToken cancellationToken)
    {
        var messageType = messageTypes.GetMessageTypeFor(outboxMessage.MessageTypeId);
        var handlerType = messageTypes.GetHandlerTypeFor(outboxMessage.MessageTypeId);
        if (!TryDeserializeMessage(outboxMessage.PayloadAsJson, messageType, out var message))
            return MessageProcessingResult.MessageUnprocessable;

        return await TryHandleMessage(message, handlerType);
    }

    private bool TryDeserializeMessage(string json, Type messageType, out Message message)
    {
        try
        {
            message = (Message) JsonConvert.DeserializeObject(json, messageType);
            return true;
        }
        catch (JsonException e)
        {
            logger.LogError(e, "Message deserialization failed");
            message = null;
            return false;
        }
    }

    private async Task<MessageProcessingResult> TryHandleMessage(Message message, Type handlerType)
    {
        using var scope = serviceScopeProvider.CreateScope();
        var handler = (MessageHandler) scope.ServiceProvider.GetService(handlerType);
        try
        {
            await handler.Handle(message);
            return MessageProcessingResult.Processed;
        }
        catch (DomainError e)
        {
            logger.LogError(e, "Domain error");
            return MessageProcessingResult.Processed;
        }
        catch (TemporaryInfrastructureError e)
        {
            logger.LogError(e, "Temporary infrastructure error");
            return MessageProcessingResult.TemporaryError;
        }
        catch (PermanentInfrastructureError e)
        {
            logger.LogCritical(e, "Permanent infrastructure error");
            return MessageProcessingResult.MessageUnprocessable;
        }
    }
}