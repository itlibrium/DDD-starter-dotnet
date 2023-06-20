using System.Threading.Tasks;

namespace MyCompany.ECommerce.TechnicalStuff.ProcessModel;

public interface QueryHandler<in TQuery, TResult>
    where TQuery : Query
{
     Task<TResult> Handle(TQuery query);
}