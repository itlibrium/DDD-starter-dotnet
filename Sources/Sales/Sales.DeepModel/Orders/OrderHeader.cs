using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyCompany.Crm.TechnicalStuff.Crud;
using MyCompany.Crm.TechnicalStuff.Metadata;
using Newtonsoft.Json;

namespace MyCompany.Crm.Sales.Orders
{
    [DataStructure]
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class OrderHeader : CrudEntity
    {
        [BindRequired]
        public Guid ClientId { get; set; }

        public InvoicingDetails InvoicingDetails { get; set; }

        [BindNever]
        [JsonIgnore]
        public List<OrderNote> Notes { get; set; }
        
        //...
    }
}