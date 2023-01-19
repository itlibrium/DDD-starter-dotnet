using System.Linq;

namespace MyCompany.Crm.TechnicalStuff.Crud.Operations
{
    public delegate IQueryable<T> QueryConfig<T>(IQueryable<T> queryable);

    public delegate IQueryable<TOut> QueryConfig<in TIn, out TOut>(IQueryable<TIn> queryable);
}