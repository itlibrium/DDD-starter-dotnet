using JetBrains.Annotations;

namespace MyCompany.ECommerce.TechnicalStuff.Outbox.Postgres
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class PostgresOutboxProcessorSettings
    {
        public int BatchSize { get; set; }
        public int CommitOffsetInterval { get; set; }
        public int CleanupThreshold { get; set; }
    }
}