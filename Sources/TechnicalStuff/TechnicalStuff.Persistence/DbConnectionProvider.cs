using System.Data.Common;

namespace MyCompany.Crm.TechnicalStuff.Persistence;

public interface DbConnectionProvider
{
    Task<DbConnection> CreateOneOffConnection();
}