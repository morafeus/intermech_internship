using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI_internship.Services.Interfaces;

namespace WebAPI_internship.Controllers
{
    [ApiController]
    [Route("api/dll")]
    public class UserPluginController : Controller
    {
        private IPluginRegisterService _pluginRegisterService;

        public UserPluginController(IPluginRegisterService pluginService)
        {
            _pluginRegisterService = pluginService;
        }

        [HttpGet]
        [Route("/load")]
        [Authorize]
        public async Task<IActionResult> LoadUserDLL(string path)
        {
            try
            {
                _pluginRegisterService.RegisterService(path);
                return Ok("соборка загружена");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
