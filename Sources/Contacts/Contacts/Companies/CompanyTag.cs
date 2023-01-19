using System;
using JetBrains.Annotations;
using MyCompany.Crm.Contacts.Tags;

namespace MyCompany.Crm.Contacts.Companies
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class CompanyTag
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}