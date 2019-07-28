using Microsoft.AspNetCore.Mvc;
using Portfolio.BusinessLogic.MainPage.GetMainPageData;
using System.Net;
using System.Threading.Tasks;

namespace Portfolio.Web.Controllers
{
    public class MainPageController : ControllerBase
    {
        [HttpGet("GetMainPageData")]
        [ProducesResponseType(typeof(GetMainPageDataResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetMainPageData([FromQuery] GetMainPageDataRequest request)
        {
            return await DispatchQueryAsync(request);
        }
    }
}