using System;

namespace MyCompany.Crm.TechnicalStuff.Crud.Operations.Results
{
    public static class CrudResult
    {
        public static Created<TEntity> Created<TEntity>(TEntity entity) where TEntity : class => new(entity);

        public static Updated Updated(Guid id) => new(id);

        public static Updated<TEntity> Updated<TEntity>(TEntity entity) where TEntity : class => new(entity);

        public static Deleted Deleted(Guid id, bool wasPresent) => new(id, wasPresent);
    }
}