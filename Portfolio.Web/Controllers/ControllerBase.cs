using Microsoft.AspNetCore.Mvc;
using Portfolio.Core.LogicAbstractions;
using Portfolio.Core.QueryAbstractions;
using Portfolio.IOC;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Portfolio.Web.Controllers
{
    public class ControllerBase : Controller
    {
        protected async Task<IActionResult> DispatchLogicAsync<Result>(ILogicIncomer<Result> incomer)
            where Result : ILogicResult
        {
            var logic = Handler.ResolveLogic<Result>();

            var logicExecution = await logic.ExecuteAsync(incomer);

            if (logicExecution.ValidationErrors.Any())
            {
                return new JsonResult(logicExecution.ValidationErrors)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
            else
            {
                return new JsonResult(logicExecution.LogicResult);
            }
        }

        protected async Task<IActionResult> DispatchQueryAsync<Result>(IQueryIncomer<Result> incomer)
        {
            var query = Handler.ResolveQuery<Result>();

            var queryExecution = await query.ExecuteAsync(incomer);

            if (queryExecution.ValidationErrors.Any())
            {
                return new JsonResult(queryExecution.ValidationErrors)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
            else
            {
                return new JsonResult(queryExecution.QueryResult);
            }
        }
    }
}
