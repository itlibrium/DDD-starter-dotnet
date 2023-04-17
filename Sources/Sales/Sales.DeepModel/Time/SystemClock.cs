using System;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.Crm.Sales.Time
{
    [DddDomainService]
    internal class SystemClock : Clock
    {
        public DateTime Now
        {
            get
            {
                var now = DateTime.UtcNow;
                return new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, now.Millisecond,
                    DateTimeKind.Utc);
            }
        }
    }
}