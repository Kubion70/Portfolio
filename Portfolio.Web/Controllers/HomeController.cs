using Microsoft.AspNetCore.Mvc;
using Portfolio.BusinessLogic.Sample;
using Portfolio.Data.Configurations;
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
        public async Task<IActionResult> Test()
        {
            return await DispatchLogicAsync(new SampleLogicIncomer());
        }
    }
}