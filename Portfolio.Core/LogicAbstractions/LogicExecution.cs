using FluentValidation.Results;
using System.Collections.Generic;

namespace Portfolio.Core.LogicAbstractions
{
    public class LogicExecution<Result> where Result : ILogicResult
    {
        public Result LogicResult { get; }

        public IList<ValidationFailure> ValidationErrors { get; } = new List<ValidationFailure>();

        public LogicExecution(IList<ValidationFailure> vlidationErrors)
        {
            ValidationErrors = vlidationErrors;
        }

        public LogicExecution(Result logicResult)
        {
            LogicResult = logicResult;
        }
    }
}
