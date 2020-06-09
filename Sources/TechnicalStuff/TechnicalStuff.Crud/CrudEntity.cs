using System;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TechnicalStuff.Crud
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class CrudEntity
    {
        [BindNever] public Guid Id { get; set; }
        [BindNever] protected internal bool IsDeleted { get; set; }
    }
}