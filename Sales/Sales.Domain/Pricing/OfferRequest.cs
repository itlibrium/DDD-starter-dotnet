using System.Collections.Immutable;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.Sales.SalesChannels;

namespace MyCompany.Crm.Sales.Pricing
{
    public readonly struct OfferRequest
    {
        public ClientId ClientId { get; }
        public SalesChannel SalesChannel { get; }
        public ImmutableArray<ProductAmount> ProductAmounts { get; }

        public OfferRequest(ClientId clientId, SalesChannel salesChannel, ImmutableArray<ProductAmount> productAmounts)
        {
            ClientId = clientId;
            SalesChannel = salesChannel;
            ProductAmounts = productAmounts;
        }
    }
}