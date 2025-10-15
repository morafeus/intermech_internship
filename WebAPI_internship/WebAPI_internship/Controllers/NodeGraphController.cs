using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI_internship.Models;
using WebAPI_internship.Services;

namespace WebAPI_internship.Controllers
{
    [ApiController]
    [Route("api/nodegraph")]
    public class NodeGraphController : Controller
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetNodes(Guid projectId)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = TokenService.GetUserFromToken(authHeader);

            var proj = Store.Projects.Where(p => (p.Id == projectId) && (p.UserId == user.Id)).FirstOrDefault();

            if (proj == null)
                return BadRequest("у вас нет доступа к данному проекту");

            var nodes = Store.Nodes.Where(n => n.ProjectId == projectId).ToList();

            if (nodes != null)
            {
                return Ok(nodes);
            }
            else
            {
                return BadRequest("у данного проекта нет нод");
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetNode(Guid id)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = TokenService.GetUserFromToken(authHeader);

            var node = Store.Nodes.Where(n => n.Id == id).FirstOrDefault();
            if (node == null)
                return BadRequest("в проекте нет ноды с таким айди");

            var proj = Store.Projects.Where(p => (p.Id == node.ProjectId) && (p.UserId == user.Id)).FirstOrDefault();
            if (proj == null)
                return BadRequest("у вас нет доступа к проекту, которому принадлежит эта нода");
            
            return Ok(node.JsonData);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddNode(Guid projectId, string name, string jsonData)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = TokenService.GetUserFromToken(authHeader);

            var proj = Store.Projects.Where(p => (p.Id == projectId) && (p.UserId == user.Id)).FirstOrDefault();

            if (proj != null)
            {
                var node = new NodeGraph(name, proj.Id, jsonData);
                Store.Nodes.Add(node);
                return Ok(node);
            }
            else
            {
                return BadRequest("такого проекта нет");
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateNode(Guid id, string? name, string? jsonData)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = TokenService.GetUserFromToken(authHeader);

            var node = Store.Nodes.Where(n => n.Id == id).FirstOrDefault();
            if (node == null)
                return BadRequest("в проекте нет ноды с таким айди");

            var proj = Store.Projects.Where(p => (p.Id == node.ProjectId) && (p.UserId == user.Id)).FirstOrDefault();
            if (proj == null)
                return BadRequest("у вас нет доступа к проекту, которому принадлежит эта нода");

            node.Name = name ?? node.Name;
            node.JsonData = jsonData ?? node.JsonData;

            return Ok(node);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteNode(Guid id)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = TokenService.GetUserFromToken(authHeader);

            var node = Store.Nodes.Where(n => n.Id == id).FirstOrDefault();
            if (node == null)
                return BadRequest("в проекте нет ноды с таким айди");

            var proj = Store.Projects.Where(p => (p.Id == node.ProjectId) && (p.UserId == user.Id)).FirstOrDefault();
            if (proj == null)
                return BadRequest("у вас нет доступа к проекту, которому принадлежит эта нода");

            Store.Nodes.Remove(node);

            return Ok(node);
        }
    }
}
