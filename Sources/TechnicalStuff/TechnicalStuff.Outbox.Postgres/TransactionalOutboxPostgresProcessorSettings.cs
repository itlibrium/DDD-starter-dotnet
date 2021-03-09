using JetBrains.Annotations;

namespace MyCompany.Crm.TechnicalStuff.Outbox.Postgres
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class TransactionalOutboxPostgresProcessorSettings
    {
        public int BatchSize { get; set; }
        public int CleanupThreshold { get; set; }
    }
}