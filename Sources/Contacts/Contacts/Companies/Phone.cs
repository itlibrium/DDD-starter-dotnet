using System;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace MyCompany.Crm.Contacts.Companies
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class Phone
    {
        [BindNever] [JsonIgnore] public Guid CompanyId { get; set; }
        [BindRequired] public string Number { get; set; }
    }
}