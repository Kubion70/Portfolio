using FluentValidation;
using System;
using System.Threading.Tasks;

namespace Portfolio.Core.LogicAbstractions
{
    public abstract class Logic<Incomer, Result> : ILogic<Result>
        where Incomer : ILogicIncomer<Result>
        where Result : ILogicResult
    {
        private IValidator<Incomer> Validator { get; set; }

        protected Logic(IValidator<Incomer> validator = null)
        {
            Validator = validator;
        }

        public async Task<LogicExecution<Result>> ExecuteAsync(ILogicIncomer<Result> incomer)
        {
            if (Validator != null)
            {
                var result = Validator.Validate(incomer);
                if (!result.IsValid)
                    return new LogicExecution<Result>(result.Errors);
            }

            return new LogicExecution<Result>(await Execute((Incomer)incomer));
        }

        protected abstract Task<Result> Execute(Incomer incomer);
    }
}
