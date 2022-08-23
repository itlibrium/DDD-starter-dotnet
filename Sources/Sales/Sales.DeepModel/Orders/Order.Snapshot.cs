using System;
using System.Collections.Immutable;

namespace MyCompany.Crm.Sales.Orders
{
    public partial class Order
    {
        public Snapshot GetSnapshot() => new(Id.Value, _items.Values.ToImmutableArray(), _isPlaced);

        public static Order RestoreFrom(Snapshot snapshot) => new(OrderId.From(snapshot.Id), snapshot.Items, snapshot.IsPlaced);

        public class Snapshot
        {
            public Guid Id { get; }
            public ImmutableArray<Item> Items { get; }
            public bool IsPlaced { get; }

            public Snapshot(Guid id, ImmutableArray<Item> items, bool isPlaced)
            {
                Id = id;
                Items = items;
                IsPlaced = isPlaced;
            }
        }
    }
}