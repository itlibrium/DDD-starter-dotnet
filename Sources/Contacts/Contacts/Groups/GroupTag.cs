using System;
using JetBrains.Annotations;
using MyCompany.Crm.Contacts.Tags;

namespace MyCompany.Crm.Contacts.Groups
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class GroupTag
    {
        public Guid GroupId { get; set; }
        public Group Group { get; set; }

        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}