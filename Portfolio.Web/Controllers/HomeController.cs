using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Configurations;

namespace Portfolio.Web.Controllers
{
    public class HomeController : Controller
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