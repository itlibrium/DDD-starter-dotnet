using System;
using MyCompany.Crm.TechnicalStuff.Metadata;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Time
{
    [Stateless]
    [DddDomainService]
    internal class SystemClock : Clock
    {
        public DateTime Now
        {
            get
            {
                var now = DateTime.UtcNow;
                return new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, now.Millisecond);
            }
        }
    }
}