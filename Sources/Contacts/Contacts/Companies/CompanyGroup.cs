using System;
using JetBrains.Annotations;
using MyCompany.ECommerce.Contacts.Groups;

namespace MyCompany.ECommerce.Contacts.Companies
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