using System.Linq;

namespace MyCompany.Crm.TechnicalStuff.Crud.DataAccess
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