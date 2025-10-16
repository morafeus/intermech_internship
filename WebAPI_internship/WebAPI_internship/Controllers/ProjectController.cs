using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetProjects()
        {
            var authHeader = Request.Headers["Authorization"];
            var user = _tokenService.GetUserFromToken(authHeader);

            var projects = await _projectService.GetProjects(user.Id);
            return Ok(projects);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddProject(string name, string description)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = _tokenService.GetUserFromToken(authHeader);

            var project = await _projectService.AddProject(name, description, user.Id);
            return Ok(project);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProject(Guid id, string? name,  string? description)
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


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProject(Guid id)
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
