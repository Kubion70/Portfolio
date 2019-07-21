using System.Threading.Tasks;

namespace Portfolio.Core.LogicAbstractions
{
    public interface ILogic<Result>
        where Result : ILogicResult
    {
        Task<LogicExecution<Result>> ExecuteAsync(ILogicIncomer<Result> incomer);
    }
}