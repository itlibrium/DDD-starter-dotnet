using MyCompany.ECommerce.TechnicalStuff.Persistence;
using MyCompany.ECommerce.TechnicalStuff.Postgres;

namespace MyCompany.ECommerce.Infrastructure;

public class CrmDb : PostgresTransactionProvider, MainDb
{
    public CrmDb(string connectionString) : base(connectionString) { }
}