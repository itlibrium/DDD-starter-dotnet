using System;

namespace MyCompany.Crm.TechnicalStuff.Metadata
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface)]
    public class DomainEvent : Attribute { }
}