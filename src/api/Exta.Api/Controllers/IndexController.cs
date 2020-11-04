using Microsoft.AspNetCore.Mvc;

namespace Exta.Api.Controllers
{
    [Route("/")]
    public class IndexController : ControllerBase
    {
        public IndexController()
        {

        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello World from Exta.Api");
        }
    }
}