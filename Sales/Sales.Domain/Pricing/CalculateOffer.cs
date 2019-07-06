using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Products;

namespace MyCompany.Crm.Sales.Pricing
{
    public class CalculateOffer
    {
        public async Task<Offer> For(ClientId clientId, Currency currency, ImmutableArray<ProductAmount> productAmounts)
        {
            // more coming soon
            throw new NotImplementedException();
        }
    }
}