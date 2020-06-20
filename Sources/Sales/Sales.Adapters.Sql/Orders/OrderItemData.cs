using System;
using JetBrains.Annotations;

namespace MyCompany.Crm.Sales.Orders
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class OrderItemData
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
        public string AmountUnit { get; set; }
        public decimal? Price { get; set; }
        public string Currency { get; set; }
    }
}