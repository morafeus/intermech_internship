using Microsoft.AspNetCore.Mvc;
using WebAPI_internship.Models;

namespace WebAPI_internship.Controllers
{
    [ApiController]
    [Route("auth/[controller]")]
    public class AuthController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> SignUp(int id, string name, string password, string description = "")
        {
            try
            {
                var passwordHash = HashService.HashPassword(password);

                var user = new User(id, name, description, passwordHash);
                return Ok("user has been created");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<string> SignIn(string name, string password, [FromServices] IConfiguration configuration)
        {
            
        }
    }
}
