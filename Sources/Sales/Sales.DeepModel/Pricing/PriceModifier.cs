using System.Diagnostics.Contracts;
using MyCompany.ECommerce.Sales.Commons;

namespace MyCompany.ECommerce.Sales.Pricing
{
    internal interface PriceModifier
    {
        [Pure]
        Money ApplyOn(Money price);
    }
}