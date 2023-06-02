using System;
using P3Model.Annotations.Domain;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.ECommerce.Sales.Time
{
    [ExcludeFromDomainGlossary]
    [DddDomainService]
    public interface Clock
    {
        DateTime Now { get; }
    }
}