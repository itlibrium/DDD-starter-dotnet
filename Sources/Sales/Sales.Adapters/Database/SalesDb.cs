using MyCompany.Crm.TechnicalStuff.Postgres;

namespace MyCompany.Crm.Sales.Database;

public class SalesDb : PostgresConnectionProvider
{
    public SalesDb(string connectionString) : base(connectionString) { }
}