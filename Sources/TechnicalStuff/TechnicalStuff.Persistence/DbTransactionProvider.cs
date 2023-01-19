using System.Data;
using System.Data.Common;

namespace MyCompany.Crm.TechnicalStuff.Persistence;

public interface DbTransactionProvider : DbConnectionProvider
{
    DbTransaction GetCurrentTransaction();
    Task BeginTransaction(IsolationLevel level = IsolationLevel.ReadCommitted);
    Task CommitCurrentTransaction();
    Task RollbackCurrentTransaction();
}