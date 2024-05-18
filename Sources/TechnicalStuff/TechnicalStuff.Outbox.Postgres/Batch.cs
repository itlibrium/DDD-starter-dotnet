using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyCompany.ECommerce.TechnicalStuff.Outbox.Postgres;

public readonly struct Batch(int requestedSize, long startingOffset, IReadOnlyCollection<OutboxMessage> messages)
    : IEnumerable<Batch.Item>
{
    public bool IsFull => messages.Count == requestedSize;

    public bool IsOffsetCommitRequiredFor(Item item, int commitInterval) =>
        IsAtIntervalEnd(item, commitInterval) ||
        IsLast(item);

    private bool IsAtIntervalEnd(Item item, int commitInterval) =>
        (item.Offset - startingOffset + 1) % commitInterval == 0; 
        
    private bool IsLast(Item item) => 
        item.Offset == startingOffset + messages.Count - 1;

    public IEnumerator<Item> GetEnumerator()
    {
        var offset = startingOffset;
        return messages.Select(m => new Item(offset++, m)).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public readonly struct Item(long offset, OutboxMessage outboxMessage)
    {
        public long Offset { get; } = offset;
        public OutboxMessage OutboxMessage { get; } = outboxMessage;
    }
}