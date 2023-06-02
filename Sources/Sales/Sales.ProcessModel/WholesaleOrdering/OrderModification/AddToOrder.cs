using System;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderModification
{
    [ProcessStepContract]
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