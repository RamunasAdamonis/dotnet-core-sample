using Microsoft.AspNetCore.Mvc;

namespace dotnet_core_sample.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        public MainController()
        {
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("It works");
        }
    }
}
