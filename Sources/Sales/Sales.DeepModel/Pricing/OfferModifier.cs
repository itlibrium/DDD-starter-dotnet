using System.Diagnostics.Contracts;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Pricing
{
    [DddPolicy]
    public interface OfferModifier
    {
        [Pure]
        Offer ApplyOn(Offer offer);
    }

    [DddPolicy]
    public delegate Offer OfferModifier2(Offer offer);
}