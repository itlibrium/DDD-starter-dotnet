using System;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.ProductsDelivery
{
    public readonly struct RequestDelivery : Command
    {
        public Guid ClientId { get; }
        
    }

    public class ProductDelivered
    {
        
    }
}