using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MyCompany.ECommerce.TechnicalStuff.Crud;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class CrudEntity
{
    [BindNever] public Guid Id { get; set; }
    [BindNever] public bool IsDeleted { get; set; }
}