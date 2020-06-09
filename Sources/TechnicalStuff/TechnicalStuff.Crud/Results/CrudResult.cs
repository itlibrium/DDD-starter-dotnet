using System;

namespace TechnicalStuff.Crud.Results
{
    public static class CrudResult
    {
        public static Created<TEntity> Created<TEntity>(TEntity entity) => new Created<TEntity>(entity);

        public static Updated Updated(Guid id) => new Updated(id);

        public static Updated<TEntity> Updated<TEntity>(TEntity entity) => new Updated<TEntity>(entity);

        public static Deleted Deleted(Guid id, bool wasPresent) => new Deleted(id, wasPresent);
    }
}