using System;

namespace MyCompany.Crm.Sales.Orders
{
    public class OrderItemDetails
    {
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
        public string AmountUnit { get; set; }
        public decimal Price { get; set; }
    }
}