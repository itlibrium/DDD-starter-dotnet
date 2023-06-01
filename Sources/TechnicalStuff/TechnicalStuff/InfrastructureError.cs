using System;

namespace MyCompany.ECommerce.TechnicalStuff
{
    public class InfrastructureError : Exception
    {
        protected InfrastructureError() { }
        
        protected InfrastructureError(string message) : base(message) { }
        
        protected InfrastructureError(string message, Exception innerException) : base(message, innerException) { }
    }
}