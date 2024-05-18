using JetBrains.Annotations;
using Microsoft.AspNetCore.JsonPatch;
using MyCompany.ECommerce.TechnicalStuff.Crud.Operations.Results;

namespace MyCompany.ECommerce.TechnicalStuff.Crud.Operations;

public interface CrudOperations
{
    [PublicAPI]
    IQueryable<TEntity> Entities<TEntity>()
        where TEntity : class;

    [PublicAPI]
    Task<bool> CheckIfExists<TEntity>(Guid id)
        where TEntity : CrudEntity;

    [PublicAPI]
    Task<Created<TEntity>> Create<TEntity>(TEntity entity)
        where TEntity : CrudEntity;

    [PublicAPI]
    Task<TEntity> Read<TEntity>(Guid id)
        where TEntity : CrudEntity;

    [PublicAPI]
    Task<TEntity> Read<TEntity>(Guid id, QueryConfig<TEntity> queryConfig)
        where TEntity : CrudEntity;

    [PublicAPI]
    Task<TResult> Read<TEntity, TResult>(Guid id, QueryConfig<TEntity, TResult> queryConfig)
        where TEntity : CrudEntity;

    [PublicAPI]
    IAsyncEnumerable<TEntity> Read<TEntity>(QueryConfig<TEntity> queryConfig)
        where TEntity : class;

    [PublicAPI]
    IAsyncEnumerable<TResult> Read<TEntity, TResult>(QueryConfig<TEntity, TResult> queryConfig)
        where TEntity : class;

    [PublicAPI]
    Task<Updated<TEntity>> Update<TEntity>(Guid id, TEntity entity)
        where TEntity : CrudEntity;

    [PublicAPI]
    Task<Updated<TEntity>> Update<TEntity>(Guid id, QueryConfig<TEntity> queryConfig, TEntity entity)
        where TEntity : CrudEntity;

    [PublicAPI]
    Task<Updated<TEntity>> Update<TEntity>(Guid id, JsonPatchDocument<TEntity> patch)
        where TEntity : CrudEntity;

    [PublicAPI]
    Task<Updated<TEntity>> Update<TEntity>(Guid id, QueryConfig<TEntity> queryConfig,
        JsonPatchDocument<TEntity> patch)
        where TEntity : CrudEntity;

    [PublicAPI]
    Task<Updated> Update<TEntity>(Guid id, Action<TEntity> updateEntity)
        where TEntity : CrudEntity;

    [PublicAPI]
    Task<Updated> Update<TEntity>(Guid id, QueryConfig<TEntity> queryConfig, Action<TEntity> updateEntity)
        where TEntity : CrudEntity;

    [PublicAPI]
    Task<Updated<TEntity>> Update<TEntity>(Guid id, Func<TEntity, TEntity> updateEntity)
        where TEntity : CrudEntity;

    [PublicAPI]
    Task<Updated<TEntity>> Update<TEntity>(Guid id, QueryConfig<TEntity> queryConfig,
        Func<TEntity, TEntity> updateEntity)
        where TEntity : CrudEntity;

    [PublicAPI]
    Task<Updated<TResult>> Update<TEntity, TResult>(Guid id, Func<TEntity, TResult> updateEntity)
        where TEntity : CrudEntity
        where TResult : class;

    [PublicAPI]
    Task<Updated<TResult>> Update<TEntity, TResult>(Guid id, QueryConfig<TEntity> queryConfig,
        Func<TEntity, TResult> updateEntity)
        where TEntity : CrudEntity
        where TResult : class;

    [PublicAPI]
    Task<Deleted> Delete<TEntity>(Guid id, DeletePolicy deletePolicy)
        where TEntity : CrudEntity;

    [PublicAPI]
    Task SaveChanges();
}