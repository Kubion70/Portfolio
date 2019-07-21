using FluentValidation.Results;
using System.Collections.Generic;

namespace Portfolio.Core.QueryAbstractions
{
    public class QueryExecution<Result>
    {
        public Result QueryResult { get; }

        public IList<ValidationFailure> ValidationErrors { get; } = new List<ValidationFailure>();

        public QueryExecution(IList<ValidationFailure> vlidationErrors)
        {
            ValidationErrors = vlidationErrors;
        }

        public QueryExecution(Result queryResult)
        {
            QueryResult = queryResult;
        }
    }
}
