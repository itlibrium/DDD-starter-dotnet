using System;

namespace MyCompany.Crm.Sales.Orders
{
    public readonly struct OrderId
    {
        public Guid Value { get; }
        
        public static OrderId From(Guid value) => throw new NotImplementedException();
        
        // more coming soon
    }
}