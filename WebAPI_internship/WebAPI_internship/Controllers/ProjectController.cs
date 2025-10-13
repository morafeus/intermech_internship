using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI_internship.Models;

namespace WebAPI_internship.Controllers
{
    [ApiController]
    [Route("/api/projects")]
    public class ProjectController : Controller
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetProjects()
        {
            var authHeader = Request.Headers["Authorization"];
            var user = TokenService.GetUserFromToken(authHeader);

            return Ok(user.Projects.ToList());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddProject(string name, string description)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = TokenService.GetUserFromToken(authHeader);

            var project = new Project(name, description, user.Id);
            user.Projects.Add(project);
            return Ok(project);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProject(Guid id, string name,  string description)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = TokenService.GetUserFromToken(authHeader);

            
            var proj = user.Projects.Where(p => p.Id == id).FirstOrDefault();

            if (proj != null)
            {
                proj.Name = name ?? proj.Name;
                proj.Description = description ?? proj.Description;
                return Ok(proj);
            }
            else
            {
                return BadRequest("такого элемента в списке нет");
            }
            
        }


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = TokenService.GetUserFromToken(authHeader);

            if (user.Projects.Where(p => p.Id == id).Any())
            {
                var proj = user.Projects.Where(p => p.Id == id).FirstOrDefault();
                user.Projects.Remove(proj);
                return Ok(proj);
            }
            else
                return BadRequest("проекта с таким айди не существует");
        }
    }
}
