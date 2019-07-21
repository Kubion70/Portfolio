using System.Threading.Tasks;

namespace Portfolio.Core.QueryAbstractions
{
    public interface IQuery<Result>
    {
        Task<QueryExecution<Result>> ExecuteAsync(IQueryRequest<Result> incomer);
    }
}