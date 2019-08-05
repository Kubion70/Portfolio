using Microsoft.AspNetCore.Mvc;
using Portfolio.BusinessLogic.MainPage.GetMainPageData;
using Portfolio.BusinessLogic.MainPage.SendContactingMail;
using System.Net;
using System.Threading.Tasks;

namespace Portfolio.Web.Controllers
{
    public class MainPageController : ControllerBase
    {
        [HttpGet(nameof(GetMainPageData))]
        [ProducesResponseType(typeof(GetMainPageDataResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetMainPageData([FromQuery] GetMainPageDataRequest request)
        {
            return await DispatchQueryAsync(request);
        }

        [HttpPost(nameof(SendContactingMail))]
        [ProducesResponseType(typeof(SendContactingMailResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SendContactingMail([FromBody] SendContactingMailRequest request)
        {
            return await DispatchLogicAsync(request);
        }
    }
}