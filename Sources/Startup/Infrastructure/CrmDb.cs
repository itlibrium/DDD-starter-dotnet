using MyCompany.Crm.TechnicalStuff.Persistence;
using MyCompany.Crm.TechnicalStuff.Postgres;

namespace MyCompany.Crm.Infrastructure;

public class CrmDb : PostgresTransactionProvider, MainDb
{
    public CrmDb(string connectionString) : base(connectionString) { }
}