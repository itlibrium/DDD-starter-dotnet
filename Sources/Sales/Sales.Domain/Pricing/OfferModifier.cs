using System.Diagnostics.Contracts;

namespace MyCompany.Crm.Sales.Pricing
{
    public interface OfferModifier
    {
        [Pure]
        Offer ApplyOn(Offer offer);
    }

    public delegate Offer OfferModifier2(Offer offer);
}