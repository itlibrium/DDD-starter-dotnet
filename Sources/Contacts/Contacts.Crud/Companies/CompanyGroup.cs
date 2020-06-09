using System;
using JetBrains.Annotations;
using MyCompany.Crm.Contacts.Groups;

namespace MyCompany.Crm.Contacts.Companies
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class CompanyGroup
    {
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }

        public Group Group { get; set; }
        public Guid GroupId { get; set; }
    }
}