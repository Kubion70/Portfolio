using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Portfolio.Core.LogicAbstractions;
using Portfolio.Core.QueryAbstractions;
using Portfolio.IOC;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Portfolio.Web.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(IList<ValidationFailure>), (int)HttpStatusCode.BadRequest)]
    public class ControllerBase : Controller
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ExceptionHandled && context.Exception != null)
            {
                context.Result = new JsonResult("An error occured while processing the request.")
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
                context.ExceptionHandled = true;
            }

            base.OnActionExecuted(context);
        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            using (var scope = Handler.BeginScope())
            {
                return base.OnActionExecutionAsync(context, next);
            }
        }

        protected async Task<IActionResult> DispatchLogicAsync<Result>(ILogicRequest<Result> request)
            where Result : ILogicResult
        {
            var logic = Handler.ResolveLogic<Result>();

            var logicExecution = await logic.ExecuteAsync(request);

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

        protected async Task<IActionResult> DispatchQueryAsync<Result>(IQueryRequest<Result> request)
        {
            var query = Handler.ResolveQuery<Result>();

            var queryExecution = await query.ExecuteAsync(request);

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