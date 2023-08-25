using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyCompany.ECommerce.TechnicalStuff.Crud;
using Newtonsoft.Json;
using P3Model.Annotations.Domain.StaticModel;

namespace MyCompany.ECommerce.Contacts.Companies;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
[AnemicEntity]
public class Company : CrudEntity
{
    public string Name { get; set; }

    [BindNever]
    public DateTime AddedOn { get; set; }

    [BindNever]
    public Address Address { get; set; }

    public List<Phone> Phones { get; set; }

    [BindNever]
    [JsonIgnore]
    public List<CompanyGroup> Groups { get; set; }

    [BindNever]
    [JsonIgnore]
    public List<CompanyTag> Tags { get; set; }
}