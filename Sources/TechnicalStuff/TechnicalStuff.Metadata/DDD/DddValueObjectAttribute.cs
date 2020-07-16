using System;

namespace MyCompany.Crm.TechnicalStuff.Metadata.DDD
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum)]
    public class DddValueObjectAttribute : Attribute { }
}