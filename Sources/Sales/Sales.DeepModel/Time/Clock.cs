using System;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.Crm.Sales.Time
{
    [DddDomainService]
    public interface Clock
    {
        DateTime Now { get; }
    }
}