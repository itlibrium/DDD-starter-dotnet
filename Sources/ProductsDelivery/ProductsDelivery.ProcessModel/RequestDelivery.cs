using System;
using MyCompany.Crm.TechnicalStuff.ProcessModel;

namespace MyCompany.Crm.ProductsDelivery
{
    public readonly struct RequestDelivery : Command
    {
        public Guid ClientId { get; }
        
    }

    public class ProductDelivered
    {
        
    }
}