using System;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.ECommerce.Sales.Time
{
    [DddDomainService]
    public class SystemClock : Clock
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