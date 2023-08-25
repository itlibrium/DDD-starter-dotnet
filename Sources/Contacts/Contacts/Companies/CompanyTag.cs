using System;
using JetBrains.Annotations;
using MyCompany.ECommerce.Contacts.Tags;
using P3Model.Annotations.Domain.StaticModel;

namespace MyCompany.ECommerce.Contacts.Companies;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
[AnemicEntity]
public class CompanyTag
{
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }

    public Guid TagId { get; set; }
    public Tag Tag { get; set; }
}