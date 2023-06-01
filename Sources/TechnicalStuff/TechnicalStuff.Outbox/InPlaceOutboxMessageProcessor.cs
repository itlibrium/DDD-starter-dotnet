using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using Newtonsoft.Json;

namespace MyCompany.ECommerce.TechnicalStuff.Outbox
{
    public class InPlaceOutboxMessageProcessor : OutboxMessageProcessor
    {
        public string ProcessorType => OutboxMessageProcessors.InPlace;

        private readonly MessageTypes _messageTypes;
        private readonly IServiceScopeFactory _serviceScopeProvider;
        private readonly ILogger<InPlaceOutboxMessageProcessor> _logger;

        public InPlaceOutboxMessageProcessor(MessageTypes messageTypes, IServiceScopeFactory serviceScopeProvider,
            ILogger<InPlaceOutboxMessageProcessor> logger)
        {
            _messageTypes = messageTypes;
            _serviceScopeProvider = serviceScopeProvider;
            _logger = logger;
        }

        public async Task<MessageProcessingResult> Process(OutboxMessage outboxMessage,
            CancellationToken cancellationToken)
        {
            var messageType = _messageTypes.GetMessageTypeFor(outboxMessage.MessageTypeId);
            var handlerType = _messageTypes.GetHandlerTypeFor(outboxMessage.MessageTypeId);
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
                _logger.LogError(e, "Message deserialization failed");
                message = null;
                return false;
            }
        }

        private async Task<MessageProcessingResult> TryHandleMessage(Message message, Type handlerType)
        {
            using var scope = _serviceScopeProvider.CreateScope();
            var handler = (MessageHandler) scope.ServiceProvider.GetService(handlerType);
            try
            {
                await handler.Handle(message);
                return MessageProcessingResult.Processed;
            }
            catch (DomainError e)
            {
                _logger.LogError(e, "Domain error");
                return MessageProcessingResult.Processed;
            }
            catch (TemporaryInfrastructureError e)
            {
                _logger.LogError(e, "Temporary infrastructure error");
                return MessageProcessingResult.TemporaryError;
            }
            catch (PermanentInfrastructureError e)
            {
                _logger.LogCritical(e, "Permanent infrastructure error");
                return MessageProcessingResult.MessageUnprocessable;
            }
        }
    }
}