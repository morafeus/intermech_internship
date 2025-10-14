using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using WebAPI_internship.Models;
using WebAPI_internship.Services;

namespace WebAPI_internship.Controllers
{
    [ApiController]
    public class UsersController : Controller
    {
        [HttpGet]
        [Authorize]
        [Route("getAll")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(Store.Users);
        }

        [HttpGet]
        [Authorize]
        [Route("getMe")]
        public async Task<IActionResult> GetMe()
        {
            var authHeader = Request.Headers["Authorization"];
            var user = TokenService.GetUserFromToken(authHeader);
            user.Projects = Store.Projects.Where(p => p.UserId == user.Id).ToList();

            foreach(var project in user.Projects)
            {
                project.Nodes = Store.Nodes.Where(n => n.ProjectId == project.Id).ToList();
            }
            
            return Ok(user);
        }
    }
}
