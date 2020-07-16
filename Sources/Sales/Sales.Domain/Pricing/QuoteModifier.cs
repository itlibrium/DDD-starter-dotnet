using System.Diagnostics.Contracts;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Pricing
{
    [DddPolicy]
    internal interface QuoteModifier
    {
        [Pure]
        Quote ApplyOn(Quote quote);
    }
}