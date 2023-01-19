using System.Diagnostics.Contracts;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Pricing
{
    [DddPolicy]
    internal interface PriceModifier
    {
        [Pure]
        Money ApplyOn(Money price);
    }
}