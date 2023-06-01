using System.Linq;

namespace MyCompany.ECommerce.TechnicalStuff.Crud.Operations
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Apply<T>(this IQueryable<T> queryable, QueryConfig<T> queryConfig) =>
            queryConfig(queryable);

        public static IQueryable<TOut> Apply<TIn, TOut>(this IQueryable<TIn> queryable,
            QueryConfig<TIn, TOut> queryConfig) =>
            queryConfig(queryable);
    }
}