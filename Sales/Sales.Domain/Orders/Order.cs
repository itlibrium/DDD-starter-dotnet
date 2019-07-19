using System;
using System.Collections.Immutable;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.Sales.Products;

namespace MyCompany.Crm.Sales.Orders
{
    // implementation coming soon
    public class Order
    {
        public OrderId Id { get; }
        
        public ImmutableArray<ProductAmount> ProductAmounts { get; }
        
        public static Order New() => throw new NotImplementedException();
        
        public static Order FromOffer(ClientId clientId, Offer offer) => throw new NotImplementedException();
        
        public void Add(ProductAmount productAmount) => throw new NotImplementedException();
        
        public void ConfirmPrices(Offer offer) => throw new NotImplementedException();
        
        public void Place() => throw new NotImplementedException();
    }
}