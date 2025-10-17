using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAPI_internship.Services.Interfaces;

namespace WebAPI_internship.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <response code="200">create new user</response>
        /// <response code="400">ошибка, если поля не были заполнены или заполнены некорректно</response>
        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp([Required] string name, [Required] string password, string description = "")
        {
            try
            {
                var user = await _authService.CreateNewUser(name, password, description);
                return Ok($"user: {user.Name} has been created");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <response code="200">успешная аутентификация</response>
        /// <response code="400">ошибка, если поля не были заполнены или заполнены некорректно</response>
        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn([Required] string name, [Required] string password)
        {
            try
            {
                var token = await _authService.LoginUser(name, password);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
