using System;

namespace MyCompany.Crm.Sales.Time
{
    internal class SystemClock : Clock
    {
        public DateTime Now => DateTime.UtcNow;
    }
}