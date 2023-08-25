using System.Collections.Generic;
using JetBrains.Annotations;
using MyCompany.ECommerce.Contacts.Companies;
using MyCompany.ECommerce.Contacts.Groups;
using MyCompany.ECommerce.TechnicalStuff.Crud;
using P3Model.Annotations.Domain.StaticModel;

namespace MyCompany.ECommerce.Contacts.Tags;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
[AnemicEntity]
public class Tag : CrudEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<CompanyTag> Companies { get; set; }
    public List<GroupTag> Groups { get; set; }
}