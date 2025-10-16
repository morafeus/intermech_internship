using Microsoft.AspNetCore.Mvc;
using WebAPI_internship.Models;
using WebAPI_internship.Services;
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

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp( string name, string password, string description = "")
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

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn(string name, string password)
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
