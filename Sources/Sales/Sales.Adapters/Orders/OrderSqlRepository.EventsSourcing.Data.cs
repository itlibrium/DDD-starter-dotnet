using System.Collections.Generic;
using MyCompany.Crm.Sales.Commons;

namespace MyCompany.Crm.Sales.Orders;

public static partial class OrderSqlRepository
{
    public partial class EventsSourcing
    {
        private class Data : Order.Data
        {
            public OrderId Id { get; init; }
            public Money MaxTotalCost { get; init; }
            public bool IsPlaced { get; set; }
            private List<Order.Item> Items { get; } = new();

            IReadOnlyCollection<Order.Item> Order.Data.Items => Items;
            public void Add(Order.Item item) => Items.Add(item);
            public void Remove(Order.Item item) => Items.Remove(item);
        }
    }
}