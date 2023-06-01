using System.Diagnostics.Contracts;
using MyCompany.ECommerce.Sales.Commons;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.ECommerce.Sales.Pricing
{
    [DddDomainService]
    internal interface PriceModifier
    {
        [Pure]
        Money ApplyOn(Money price);
    }
}