using System;

namespace MyCompany.Crm.Sales.Orders
{
    public class AllOrderDetails
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        // TODO: items with prices, invoicing details, notes, etc.
    }
}