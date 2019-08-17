using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Products;

namespace MyCompany.Crm.Sales.Pricing
{
    // implementation coming soon
    public class CalculatePrices
    {
        public async Task<Quote> For(ClientId clientId, ProductAmount productAmount, Currency currency) => 
            throw new NotImplementedException();

        public async Task<Offer> For(ClientId clientId, IEnumerable<ProductAmount> productAmounts, Currency currency) 
            => throw new NotImplementedException();
    }
}