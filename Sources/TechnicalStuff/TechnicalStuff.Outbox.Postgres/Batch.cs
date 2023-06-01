using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyCompany.ECommerce.TechnicalStuff.Outbox.Postgres
{
    public readonly struct Batch : IEnumerable<Batch.Item>
    {
        private readonly int _requestedSize;
        private readonly long _startingOffset;
        private readonly IReadOnlyCollection<OutboxMessage> _messages;

        public bool IsFull => _messages.Count == _requestedSize;

        public Batch(int requestedSize, long startingOffset, IReadOnlyCollection<OutboxMessage> messages)
        {
            _requestedSize = requestedSize;
            _startingOffset = startingOffset;
            _messages = messages;
        }

        public bool IsOffsetCommitRequiredFor(Item item, int commitInterval) =>
            IsAtIntervalEnd(item, commitInterval) ||
            IsLast(item);

        private bool IsAtIntervalEnd(Item item, int commitInterval) =>
            (item.Offset - _startingOffset + 1) % commitInterval == 0; 
        
        private bool IsLast(Item item) => 
            item.Offset == _startingOffset + _messages.Count - 1;

        public IEnumerator<Item> GetEnumerator()
        {
            var offset = _startingOffset;
            return _messages.Select(m => new Item(offset++, m)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public readonly struct Item
        {
            public long Offset { get; }
            public OutboxMessage OutboxMessage { get; }

            public Item(long offset, OutboxMessage outboxMessage)
            {
                Offset = offset;
                OutboxMessage = outboxMessage;
            }
        }
    }
}