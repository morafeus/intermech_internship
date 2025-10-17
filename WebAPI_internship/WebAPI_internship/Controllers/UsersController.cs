using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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


        /// <response code="200">список зарегестированных пользователей</response>
        [HttpGet]
        [Authorize]
        [Route("getAll")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(Store.Users);
        }


        /// <response code="200">профиль пользователя со списками доступных проектов и нод внтури них</response>
        /// <response code="400">ошибка, если пользователь не авторизован</response>
        [HttpGet]
        [Authorize]
        [Route("getMe")]
        public async Task<IActionResult> GetMe()
        {
            try
            {
                var authHeader = Request.Headers["Authorization"];
                var user = _tokenService.GetUserFromToken(authHeader);
                user = await _userService.GetUserProfile(user);
                return Ok(user);
            } 
            catch
            {
                return BadRequest("вы не авторизованы в системе");
            }
        }
    }
}
