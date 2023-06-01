using System.Diagnostics.Contracts;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.ECommerce.Sales.Pricing
{
    [DddDomainService]
    internal interface QuoteModifier
    {
        [Pure]
        Quote ApplyOn(Quote quote);
    }
}