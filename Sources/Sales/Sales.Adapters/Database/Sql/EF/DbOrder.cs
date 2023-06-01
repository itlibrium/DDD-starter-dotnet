using System.Collections.Generic;
using JetBrains.Annotations;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Orders;

namespace MyCompany.ECommerce.Sales.Database.Sql.EF
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class DbOrder : Order.Data
    {
        public OrderId Id { get; set; }
        public Money MaxTotalCost { get; set; }
        public bool IsPlaced { get; set; }
        public int Version { get; set; }
        public List<Order.Item> Items { get; set; }

        IReadOnlyCollection<Order.Item> Order.Data.Items => Items;
        public void Add(Order.Item item) => Items.Add(item);
        public void Remove(Order.Item item) => Items.Remove(item);
    }
}