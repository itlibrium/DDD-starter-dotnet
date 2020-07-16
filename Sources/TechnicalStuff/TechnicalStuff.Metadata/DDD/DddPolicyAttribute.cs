using System;

namespace MyCompany.Crm.TechnicalStuff.Metadata.DDD
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface |
                    AttributeTargets.Delegate)]
    public class DddPolicyAttribute : Attribute { }
}