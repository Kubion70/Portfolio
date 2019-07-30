using System;
using System.Threading.Tasks;

namespace Portfolio.Core.QueryAbstractions
{
    public interface IQuery<Result> : IDisposable
    {
        Task<QueryExecution<Result>> ExecuteAsync(IQueryRequest<Result> request);
    }
}