using MyCompany.ECommerce.TechnicalStuff.Persistence;
using MyCompany.ECommerce.TechnicalStuff.Postgres;
using P3Model.Annotations.Technology;

namespace MyCompany.ECommerce.Infrastructure;

[Database("Main", ClusterName = "Postgres")]
public class MainECommerceDb : PostgresTransactionProvider, MainDb
{
    public MainECommerceDb(string connectionString) : base(connectionString) { }
}