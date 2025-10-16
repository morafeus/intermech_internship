using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI_internship.Services;
using WebAPI_internship.Services.Interfaces;

namespace WebAPI_internship.Controllers
{
    [ApiController]
    public class UsersController : Controller
    {

        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public UsersController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

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
            var user = _tokenService.GetUserFromToken(authHeader);
            user = await _userService.GetUserProfile(user);
            
            return Ok(user);
        }
    }
}
