using FluentValidation;
using Portfolio.Core.Contexts;
using Portfolio.Core.Database;
using Portfolio.Core.Translations;
using System;
using System.Threading.Tasks;

namespace Portfolio.Core.LogicAbstractions
{
    public abstract class Logic<Request, Result> : ILogic<Result>
        where Request : ILogicRequest<Result>
        where Result : ILogicResult
    {
        public IUserContext UserContext { get; set; }

        public ITranslator Translator { get; set; }

        public IDatabaseWrapper Database { get; set; }

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

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        public void Dispose()
        {
            if (!disposedValue)
            {
                Validator = null;
                Database = null;
                Translator = null;
                UserContext = null;

                disposedValue = true;
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}