using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace MyCompany.Crm.Sales.Orders
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class OrderData
    {
        public Guid Id { get; set; }
        public List<OrderItemData> Items { get; set; }
        public string PriceAgreementType { get; set; }
        public DateTime? PriceAgreementExpiresOn { get; set; }
        public bool IsPlaced { get; set; }
    }
}