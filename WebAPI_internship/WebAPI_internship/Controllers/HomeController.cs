using Microsoft.AspNetCore.Mvc;

namespace WebAPI_internship.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "hello world";
        }
    }
}
