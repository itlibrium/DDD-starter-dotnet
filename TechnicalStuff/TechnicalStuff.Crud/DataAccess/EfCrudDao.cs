using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using TechnicalStuff.Crud.Results;

namespace TechnicalStuff.Crud.DataAccess
{
    public class EfCrudDao : CrudDao
    {
        private readonly DbContext _dbContext;

        protected EfCrudDao(DbContext dbContext) => _dbContext = dbContext;

        public IQueryable<TEntity> Entities<TEntity>() where TEntity : class => _dbContext.Set<TEntity>();

        public Task<bool> CheckIfExists<TEntity>(Guid id) where TEntity : CrudEntity =>
            Entities<TEntity>().AnyAsync(e => e.Id == id);

        public async Task<Created<TEntity>> Create<TEntity>(TEntity entity)
            where TEntity : CrudEntity
        {
            if (entity.Id != Guid.Empty)
                throw new InvalidOperationException();
            if (entity.IsDeleted)
                throw new InvalidOperationException();
            entity.Id = Guid.NewGuid();
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return CrudResult.Created(entity);
        }

        public Task<TEntity> Read<TEntity>(Guid id)
            where TEntity : CrudEntity =>
            Read(id, Config<TEntity>.Empty);

        public Task<TEntity> Read<TEntity>(Guid id, QueryConfig<TEntity> queryConfig)
            where TEntity : CrudEntity =>
            GetById<TEntity>(id, query => query
                .AsNoTracking()
                .Apply(queryConfig));

        public Task<TResult> Read<TEntity, TResult>(Guid id, QueryConfig<TEntity, TResult> queryConfig)
            where TEntity : CrudEntity =>
            GetById<TEntity, TResult>(id, query => query
                .AsNoTracking()
                .Apply(queryConfig));

        public IAsyncEnumerable<TEntity> Read<TEntity>(QueryConfig<TEntity> queryConfig)
            where TEntity : class =>
            Entities<TEntity>()
                .AsNoTracking()
                .Apply(queryConfig)
                .AsAsyncEnumerable();

        public IAsyncEnumerable<TResult> Read<TEntity, TResult>(QueryConfig<TEntity, TResult> queryConfig)
            where TEntity : class =>
            Entities<TEntity>()
                .AsNoTracking()
                .Apply(queryConfig)
                .AsAsyncEnumerable();

        public Task<Updated<TEntity>> Update<TEntity>(Guid id, TEntity entity) 
            where TEntity : CrudEntity =>
            Update(id, Config<TEntity>.Empty, entity);

        public async Task<Updated<TEntity>> Update<TEntity>(Guid id, QueryConfig<TEntity> queryConfig, TEntity entity)
            where TEntity : CrudEntity
        {
            entity.Id = id;
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            return CrudResult.Updated(entity);
        }

        public Task<Updated<TEntity>> Update<TEntity>(Guid id, JsonPatchDocument<TEntity> patch)
            where TEntity : CrudEntity =>
            Update(id, Config<TEntity>.Empty, patch);

        public async Task<Updated<TEntity>> Update<TEntity>(Guid id, QueryConfig<TEntity> queryConfig,
            JsonPatchDocument<TEntity> patch)
            where TEntity : CrudEntity
        {
            var entity = await GetById(id, queryConfig);
            patch.ApplyTo(entity);
            await _dbContext.SaveChangesAsync();
            return CrudResult.Updated(entity);
        }

        public Task<Updated> Update<TEntity>(Guid id, Action<TEntity> updateEntity)
            where TEntity : CrudEntity =>
            Update(id, Config<TEntity>.Empty, updateEntity);

        public async Task<Updated> Update<TEntity>(Guid id, QueryConfig<TEntity> queryConfig, 
            Action<TEntity> updateEntity)
            where TEntity : CrudEntity
        {
            var entity = await GetById(id, queryConfig);
            updateEntity(entity);
            await _dbContext.SaveChangesAsync();
            return CrudResult.Updated(id);
        }

        public Task<Updated<TEntity>> Update<TEntity>(Guid id, Func<TEntity, TEntity> updateEntity)
            where TEntity : CrudEntity =>
            Update<TEntity>(id, Config<TEntity>.Empty, updateEntity);

        public async Task<Updated<TEntity>> Update<TEntity>(Guid id, QueryConfig<TEntity> queryConfig,
            Func<TEntity, TEntity> updateEntity)
            where TEntity : CrudEntity
        {
            var entity = await GetById(id, queryConfig);
            var updatedEntity = updateEntity(entity);
            await _dbContext.SaveChangesAsync();
            return CrudResult.Updated(updatedEntity);
        }

        public Task<Updated<TResult>> Update<TEntity, TResult>(Guid id, Func<TEntity, TResult> updateEntity)
            where TEntity : CrudEntity =>
            Update(id, Config<TEntity>.Empty, updateEntity);

        public async Task<Updated<TResult>> Update<TEntity, TResult>(Guid id, QueryConfig<TEntity> queryConfig,
            Func<TEntity, TResult> updateEntity)
            where TEntity : CrudEntity
        {
            var entity = await GetById(id, queryConfig);
            var result = updateEntity(entity);
            await _dbContext.SaveChangesAsync();
            return CrudResult.Updated(result);
        }

        public async Task<Deleted> Delete<TEntity>(Guid id, DeletePolicy deletePolicy)
            where TEntity : CrudEntity
        {
            var entity = await Entities<TEntity>().SingleOrDefaultAsync(e => e.Id == id);
            if (entity is null || entity.IsDeleted)
                return new Deleted(id, false);
            
            switch (deletePolicy)
            {
                case DeletePolicy.Soft:
                    entity.IsDeleted = true;
                    break;
                case DeletePolicy.Hard:
                    _dbContext.Set<TEntity>().Remove(entity);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(deletePolicy),
                        deletePolicy,
                        $"Unsupported {nameof(DeletePolicy)}");
            }
            await _dbContext.SaveChangesAsync();
            return CrudResult.Deleted(id, true);
        }

        public Task SaveChanges() => _dbContext.SaveChangesAsync();

        private async Task<TEntity> GetById<TEntity>(Guid id, QueryConfig<TEntity> queryConfig)
            where TEntity : CrudEntity
        {
            var result = await Entities<TEntity>()
                .Apply(queryConfig)
                .SingleOrDefaultAsync(entity => entity.Id == id);
            if (result is null)
                throw new CrudEntityNotFound(typeof(TEntity), id);
            return result;
        }

        private async Task<TResult> GetById<TEntity, TResult>(Guid id, QueryConfig<TEntity, TResult> queryConfig)
            where TEntity : CrudEntity
        {
            var result = await Entities<TEntity>()
                .Where(entity => entity.Id == id)
                .Apply(queryConfig)
                .SingleOrDefaultAsync();
            if (result is null)
                throw new CrudEntityNotFound(typeof(TEntity), id);
            return result;
        }

        private static class Config<T>
        {
            public static QueryConfig<T> Empty { get; } = queryable => queryable;
        }
    }
}