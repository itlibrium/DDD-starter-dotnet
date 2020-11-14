using System;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Time
{
    [DddDomainService]
    public interface Clock
    {
        DateTime Now { get; }
    }
}