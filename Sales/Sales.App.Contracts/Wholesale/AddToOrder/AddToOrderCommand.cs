using System;

namespace MyCompany.Crm.Sales.Wholesale.AddToOrder
{
    public readonly struct AddToOrderCommand
    {
        public Guid OrderId { get; }
        public Guid ProductId { get; }
        public int Amount { get; }
        public string UnitCode { get; }

        public AddToOrderCommand(Guid orderId, Guid productId, int amount, string unitCode)
        {
            OrderId = orderId;
            ProductId = productId;
            Amount = amount;
            UnitCode = unitCode;
        }
    }
}