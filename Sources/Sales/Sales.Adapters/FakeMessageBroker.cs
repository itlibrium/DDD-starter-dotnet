using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Sales
{
    public class FakeMessageBroker
    {
        private readonly Channel<Command> _commands = Channel.CreateUnbounded<Command>(new UnboundedChannelOptions
        {
            SingleWriter = false,
            SingleReader = true,
            AllowSynchronousContinuations = false
        });

        private readonly Channel<DomainEvent> _events = Channel.CreateUnbounded<DomainEvent>(new UnboundedChannelOptions
        {
            SingleWriter = false,
            SingleReader = true,
            AllowSynchronousContinuations = false
        });

        public void Publish(Command command)
        {
            if (!_commands.Writer.TryWrite(command))
                throw new InvalidOperationException();
        }

        public void Publish(DomainEvent domainEvent)
        {
            if (!_events.Writer.TryWrite(domainEvent))
                throw new InvalidOperationException();
        }

        public ValueTask<Command> ReadCommand(CancellationToken cancellationToken) =>
            _commands.Reader.ReadAsync(cancellationToken);

        public ValueTask<DomainEvent> ReadEvent(CancellationToken cancellationToken) =>
            _events.Reader.ReadAsync(cancellationToken);
    }
}