using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Configurations;

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
    }
}