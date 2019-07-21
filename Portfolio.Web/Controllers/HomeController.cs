using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Portfolio.BusinessLogic.Sample;
using Portfolio.Data.Configurations;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Portfolio.Web.Controllers
{
    public class HomeController : ControllerBase
    {
        private ClientAppConfiguration ClientAppConfiguration { get; set; }

        public HomeController(ClientAppConfiguration clientAppConfiguration)
        {
            ClientAppConfiguration = clientAppConfiguration;
        }

        public IActionResult Index()
        {
            return RedirectPermanent(ClientAppConfiguration.RedirectUrl);
        }

        [HttpGet("Test")]
        [ProducesResponseType(typeof(SampleLogicResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IList<ValidationFailure>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Test(SampleLogicRequest incomer)
        {
            return await DispatchLogicAsync(incomer);
        }
    }
}