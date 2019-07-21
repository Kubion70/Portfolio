using FluentValidation;
using System.Data;
using System.Threading.Tasks;

namespace Portfolio.Core.LogicAbstractions
{
    public abstract class Logic<Request, Result> : ILogic<Result>
        where Request : ILogicRequest<Result>
        where Result : ILogicResult
    {
        public IDbConnection DbConnection { get; set; }

        public IValidator<Request> Validator { get; set; }

        public async Task<LogicExecution<Result>> ExecuteAsync(ILogicRequest<Result> request)
        {
            if (Validator != null)
            {
                var result = Validator.Validate(request);
                if (!result.IsValid)
                    return new LogicExecution<Result>(result.Errors);
            }

            return new LogicExecution<Result>(await Execute((Request)request));
        }

        protected abstract Task<Result> Execute(Request request);
    }
}
