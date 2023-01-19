using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyCompany.Crm.Contacts.Companies;
using MyCompany.Crm.TechnicalStuff.Crud;
using Newtonsoft.Json;

namespace MyCompany.Crm.Contacts.Groups
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class Group : CrudEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [BindNever] [JsonIgnore] public List<CompanyGroup> Companies { get; set; }
        [BindNever] [JsonIgnore] public List<GroupTag> Tags { get; set; }
    }
}