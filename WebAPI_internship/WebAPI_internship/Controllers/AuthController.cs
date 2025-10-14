using Microsoft.AspNetCore.Mvc;
using WebAPI_internship.Models;
using WebAPI_internship.Services;

namespace WebAPI_internship.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp( string name, string password, string description = "")
        {
            try
            {
                var passwordHash = HashService.HashPassword(password);

                var user = new User(name, description, passwordHash);
                if(Store.Users.Where(u => u.Name  == name).Any()) 
                        {
                    throw new Exception("пользоватль с таким именем уже есть");
                }

                Store.Users.Add(user);

                return Ok("user has been created");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn(string name, string password, [FromServices] IConfiguration configuration)
        {
            try
            {
                if(Store.Users.Where(u => u.Name == name).Any())
                {
                    var user = Store.Users.Where(u => u.Name == name).FirstOrDefault();

                    if(HashService.VerifyPassword(password, user.PasswordHash))
                    {
                        var tokenService = new TokenService(configuration);
                        return Ok(tokenService.GenerateAccessToken(user.Id, user.Name));
                    }
                    else
                    {
                        throw new Exception("неверный пароль");
                    }
                }
                else
                {
                    throw new Exception("пользователя с таким логином не существует");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
