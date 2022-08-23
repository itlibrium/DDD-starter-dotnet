using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.Sales.Products;
using TechnicalStuff.Postgres;

namespace MyCompany.Crm.Sales
{
    public class SalesDb : PostgresConnectionFactory
    {
        public SalesDb(string connectionString) : base(connectionString) { }
        
        [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
        public class Order
        {
            public OrderId Id { get; set; }
            public List<Orders.Order.Item> Items { get; set; }
            public bool IsPlaced { get; set; }
            public int Version { get; set; }

            public Orders.Order.Item GetItemFor(ProductAmount productAmount) => 
                Items.SingleOrDefault(i => i.ProductAmount.Equals(productAmount));
        }
    }
}