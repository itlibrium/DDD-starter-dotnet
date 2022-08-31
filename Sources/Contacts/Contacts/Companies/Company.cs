using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyCompany.Crm.TechnicalStuff.Crud;
using Newtonsoft.Json;

namespace MyCompany.Crm.Contacts.Companies
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class Company : CrudEntity
    {
        public string Name { get; set; }
        [BindNever] public DateTime AddedOn { get; set; }
        [BindNever] public Address Address { get; set; }
        public List<Phone> Phones { get; set; }
        [BindNever] [JsonIgnore] public List<CompanyGroup> Groups { get; set; }
        [BindNever] [JsonIgnore] public List<CompanyTag> Tags { get; set; }
    }
}