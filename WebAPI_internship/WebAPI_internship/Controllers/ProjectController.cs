using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using WebAPI_internship.Models;
using WebAPI_internship.Services;
using WebAPI_internship.Services.Interfaces;

namespace WebAPI_internship.Controllers
{
    [ApiController]
    [Route("/api/projects")]
    public class ProjectController : Controller
    {

        private readonly ITokenService _tokenService;
        private readonly IProjectService _projectService;

        public ProjectController(ITokenService tokenService, IProjectService projectService)
        {
            _tokenService = tokenService;
            _projectService = projectService;
        }

        /// <response code="200">список проектов пользователя</response>
        /// <response code="400">ошибка, если у пользователя нет доступа к данному проекту</response>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetProjects()
        {
            var authHeader = Request.Headers["Authorization"];
            var user = _tokenService.GetUserFromToken(authHeader);

            var projects = await _projectService.GetProjects(user.Id);
            return Ok(projects);
        }

        /// <response code="200">созданный проект</response>
        /// <response code="400">ошибка, сли поля были заполнены некорректно</response>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddProject([Required] string name, [Required] string description)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = _tokenService.GetUserFromToken(authHeader);

            var project = await _projectService.AddProject(name, description, user.Id);
            return Ok(project);
        }

        /// <param name="id">идентефикатор проекта, который принадлежит пользователю</param>
        /// <response code="200">измененный проект с указанным идентификатором</response>
        /// <response code="400">ошибка, если у пользователя нет доступа к данном проекту</response>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProject([Required] Guid id, string? name,  string? description)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = _tokenService.GetUserFromToken(authHeader);
            
            try
            {
                var proj = await _projectService.ChangeProject(id, user.Id, name, description);
                return Ok(proj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        /// <param name="id">идентефикатор проекта, который принадлежит пользователю</param>
        /// <response code="200">удаленный проект с указанным идентификатором</response>
        /// <response code="400">ошибка, если у пользователя нет доступа к данном проекту</response>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProject([Required] Guid id)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = _tokenService.GetUserFromToken(authHeader);

            try
            {
                var proj = await _projectService.RemoveProject(id, user.Id);
                return Ok(proj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
