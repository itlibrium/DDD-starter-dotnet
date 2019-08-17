using System;

namespace MyCompany.Crm.Sales.Time
{
    public interface Clock
    {
        DateTime Now { get; }
    }
}