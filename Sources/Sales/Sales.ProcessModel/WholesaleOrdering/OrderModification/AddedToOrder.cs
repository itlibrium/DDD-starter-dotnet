using System;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderModification
{
    public class AddedToOrder : OrderEvent
    {
        public Guid OrderId { get; }
        public Guid ProductId { get; }
        public int Amount { get; }
        public string UnitCode { get; }

        public AddedToOrder(Guid orderId, Guid productId, int amount, string unitCode)
        {
            OrderId = orderId;
            ProductId = productId;
            Amount = amount;
            UnitCode = unitCode;
        }
    }
}