using System.Data;
using RepoDb;

namespace MyCompany.ECommerce.TechnicalStuff.Persistence.RepoDb;

public abstract class RootEntityData<TDbEntity, TId>
    where TDbEntity : class, DbRootEntity<TId>
    where TId : notnull
{
    private readonly TDbEntity? _originalDbEntity;
    private bool _isSaved;
    
    protected RootEntityData(TDbEntity? originalDbEntity) => _originalDbEntity = originalDbEntity;

    public async Task Save(IDbTransaction transaction)
    {
        if (_isSaved)
            throw new DesignError("Can not save root db entity twice");
        if (_originalDbEntity is null)
            await SaveNewEntity(transaction);
        else
            await UpdateExistingEntity(transaction);
        _isSaved = true;
    }

    private async Task SaveNewEntity(IDbTransaction transaction)
    {
        var currentDbEntity = ToDbEntity(0);
        await transaction.Connection.InsertAsync(currentDbEntity, transaction: transaction);
        await SaveNestedDbEntities(transaction);
    }
    
    private async Task UpdateExistingEntity(IDbTransaction transaction)
    {
        var currentDbEntity = ToDbEntity(_originalDbEntity!.Version + 1);
        var rowsAffected = await transaction.Connection.UpdateAsync(currentDbEntity,
            where: new QueryField[]
            {
                new(nameof(DbRootEntity<TId>.Id), _originalDbEntity.Id),
                new(nameof(DbRootEntity<TId>.Version), _originalDbEntity.Version)
            },
            transaction: transaction);
        if (rowsAffected == 0)
            throw new OptimisticLockException();
        if (rowsAffected > 1)
            throw new DesignError("More than one row affected when updating root entity - check where clause");
        await SaveNestedDbEntities(transaction);
    }

    protected abstract TDbEntity ToDbEntity(int version);

    protected abstract Task SaveNestedDbEntities(IDbTransaction transaction);
}