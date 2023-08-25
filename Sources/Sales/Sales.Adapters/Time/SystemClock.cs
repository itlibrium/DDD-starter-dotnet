using System;

namespace MyCompany.ECommerce.Sales.Time
{
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