using System;

namespace MyCompany.Crm.TechnicalStuff
{
    public class DesignError : Exception
    {
        public DesignError(string? message) : base(message) { }
    }
}