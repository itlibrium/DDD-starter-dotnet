using System.Linq;

namespace TechnicalStuff.Crud.DataAccess
{
    public delegate IQueryable<T> QueryConfig<T>(IQueryable<T> queryable);

    public delegate IQueryable<TOut> QueryConfig<in TIn, out TOut>(IQueryable<TIn> queryable);
}