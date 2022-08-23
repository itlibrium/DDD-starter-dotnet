using TechnicalStuff.Postgres;

namespace MyCompany.Crm.Sales.Database;

public class SalesDb : PostgresConnectionFactory
{
    public SalesDb(string connectionString) : base(connectionString) { }
}