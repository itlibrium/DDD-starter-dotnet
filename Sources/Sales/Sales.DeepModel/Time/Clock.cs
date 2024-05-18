using System;
using P3Model.Annotations.Domain;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Time
{
    [ExcludeFromDomainGlossary]
    [DddDomainService]
    public interface Clock
    {
        DateTime Now { get; }
    }
}