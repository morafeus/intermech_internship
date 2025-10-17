using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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

        /// <remarks>
        /// Sample request:
        ///
        ///     GET /load
        ///     {
        ///        "path": ""..\..\WebAPI_internship\ClientCustomNodes\bin\Debug\ClientCustomNodes.dll""
        ///     }
        ///
        /// </remarks>
        /// <response code="200">сборка пользовательских нод успешно добавлена</response>
        /// <response code="400">ошибка, если сборки с пользовательскими нодами по данному пути не обнаружено</response>
        [HttpGet]
        [Route("/load")]
        [Authorize]
        public async Task<IActionResult> LoadUserDLL([Required] string path)
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
