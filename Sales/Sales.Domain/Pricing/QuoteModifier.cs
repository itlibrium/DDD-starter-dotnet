using System.Diagnostics.Contracts;

namespace MyCompany.Crm.Sales.Pricing
{
    internal interface QuoteModifier
    {
        [Pure]
        Quote ApplyOn(Quote quote);
    }
}