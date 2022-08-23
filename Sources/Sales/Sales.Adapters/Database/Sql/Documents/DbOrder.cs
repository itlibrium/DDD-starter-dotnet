using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using MyCompany.Crm.Sales.Orders;

namespace MyCompany.Crm.Sales.Database.Sql.Documents;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class DbOrder : Order.Data
{
    public Guid Id { get; set; }

    // Marten doesn't support value objects as identifiers.
    OrderId Order.Data.Id
    {
        get => new(Id);
        set => Id = value.Value;
    }

    public bool IsPlaced { get; set; }
    public List<Order.Item> Items { get; set; }
}