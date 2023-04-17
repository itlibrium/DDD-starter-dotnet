using System.Diagnostics.Contracts;
using MyCompany.Crm.Sales.Commons;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.Crm.Sales.Pricing
{
    [DddDomainService]
    internal interface PriceModifier
    {
        [Pure]
        Money ApplyOn(Money price);
    }
}