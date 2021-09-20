using System;
using System.Collections.Generic;

namespace MyCompany.Crm.Sales.Orders
{
    public class AllOrderDetails
    {
        //TODO: DomainModel + Raw
        public Guid ClientId { get; set; }
        public string CurrencyCode { get; set; }
        public List<OrderItemDetails> Items { get; set; }
        // TODO: invoicing details, notes, etc.
    }
}