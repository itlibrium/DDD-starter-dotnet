using System.Collections.Generic;
using JetBrains.Annotations;
using MyCompany.Crm.Contacts.Companies;
using MyCompany.Crm.Contacts.Groups;
using TechnicalStuff.Crud;

namespace MyCompany.Crm.Contacts.Tags
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class Tag : CrudEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CompanyTag> Companies { get; set; }
        public List<GroupTag> Groups { get; set; }
    }
}