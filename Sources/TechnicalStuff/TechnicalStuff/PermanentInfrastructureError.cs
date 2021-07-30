using System;

namespace MyCompany.Crm.TechnicalStuff
{
    public class PermanentInfrastructureError : InfrastructureError
    {
        public PermanentInfrastructureError() { }

        public PermanentInfrastructureError(string message) : base(message) { }

        public PermanentInfrastructureError(string message, Exception innerException) :
            base(message, innerException) { }
    }
}