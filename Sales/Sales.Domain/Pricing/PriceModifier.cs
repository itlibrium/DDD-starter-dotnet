using System.Diagnostics.Contracts;
using MyCompany.Crm.Sales.Commons;

namespace MyCompany.Crm.Sales.Pricing
{
    internal interface PriceModifier
    {
        [Pure]
        Money ApplyOn(Money price);
    }
}