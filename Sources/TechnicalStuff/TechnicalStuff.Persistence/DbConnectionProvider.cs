using System.Data.Common;

namespace MyCompany.ECommerce.TechnicalStuff.Persistence;

public interface DbConnectionProvider
{
    Task<DbConnection> CreateOneOffConnection();
}