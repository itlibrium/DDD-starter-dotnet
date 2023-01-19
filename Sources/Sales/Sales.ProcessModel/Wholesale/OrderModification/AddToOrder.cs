using System;
using MyCompany.Crm.TechnicalStuff.ProcessModel;

namespace MyCompany.Crm.Sales.Wholesale.OrderModification
{
    public readonly struct AddToOrder : Command
    {
        public Guid OrderId { get; }
        public Guid ProductId { get; }
        public int Amount { get; }
        public string UnitCode { get; }

        public AddToOrder(Guid orderId, Guid productId, int amount, string unitCode)
        {
            OrderId = orderId;
            ProductId = productId;
            Amount = amount;
            UnitCode = unitCode;
        }
    }
}