using System;
using System.Threading.Tasks;

namespace Portfolio.Core.LogicAbstractions
{
    public interface ILogic<Result> : IDisposable
        where Result : ILogicResult
    {
        Task<LogicExecution<Result>> ExecuteAsync(ILogicRequest<Result> request);
    }
}