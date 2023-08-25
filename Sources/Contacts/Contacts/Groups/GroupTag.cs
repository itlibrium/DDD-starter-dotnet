using System;
using JetBrains.Annotations;
using MyCompany.ECommerce.Contacts.Tags;
using P3Model.Annotations.Domain.StaticModel;

namespace MyCompany.ECommerce.Contacts.Groups;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
[AnemicEntity]
public class GroupTag
{
    public Guid GroupId { get; set; }
    public Group Group { get; set; }

    public Guid TagId { get; set; }
    public Tag Tag { get; set; }
}