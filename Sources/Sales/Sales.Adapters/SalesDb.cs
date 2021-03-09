using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TechnicalStuff.Postgres;

namespace MyCompany.Crm.Sales
{
    public class SalesDb : PostgresConnectionFactory
    {
        public SalesDb(string connectionString) : base(connectionString) { }
        
        [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
        public class Order
        {
            public Guid Id { get; set; }
            public List<OrderItem> Items { get; set; }
            public string PriceAgreementType { get; set; }
            public DateTime? PriceAgreementExpiresOn { get; set; }
            public bool IsPlaced { get; set; }
        }
        
        [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
        public class OrderItem
        {
            public Guid OrderId { get; set; }
            public Guid ProductId { get; set; }
            public int Amount { get; set; }
            public string AmountUnit { get; set; }
            public decimal? Price { get; set; }
            public string Currency { get; set; }
        }
    }
}