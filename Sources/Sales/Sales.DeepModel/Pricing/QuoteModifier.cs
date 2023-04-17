using System.Diagnostics.Contracts;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.Crm.Sales.Pricing
{
    [DddDomainService]
    internal interface QuoteModifier
    {
        [Pure]
        Quote ApplyOn(Quote quote);
    }
}