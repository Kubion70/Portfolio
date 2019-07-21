using FluentValidation;
using System.Data;
using System.Threading.Tasks;

namespace Portfolio.Core.QueryAbstractions
{
    public abstract class Query<Incomer, Result> : IQuery<Result> where Incomer : IQueryIncomer<Result>
    {
        public IDbConnection DbConnection { get; set; }

        public IValidator<Incomer> Validator { get; set; }

        public async Task<QueryExecution<Result>> ExecuteAsync(IQueryIncomer<Result> incomer)
        {
            if (Validator != null)
            {
                var result = Validator.Validate(incomer);
                if (!result.IsValid)
                {
                    return new QueryExecution<Result>(result.Errors);
                }
            }

            return new QueryExecution<Result>(await Execute((Incomer)incomer));
        }

        protected abstract Task<Result> Execute(Incomer incomer);
    }
}
