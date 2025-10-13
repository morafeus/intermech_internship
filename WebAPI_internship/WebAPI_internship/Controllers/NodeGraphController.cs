using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebAPI_internship.Models;

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

            var proj = user.Projects.Where(p => p.Id == projectId).FirstOrDefault();

            if (proj != null)
            {
                return Ok(proj.Nodes);
            }
            else
            {
                return BadRequest("такого проекта нет");
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetNode(Guid id)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = TokenService.GetUserFromToken(authHeader);

            var node = user.Projects.SelectMany(p => p.Nodes).FirstOrDefault(n => n.Id == id);

            if (node != null)
                return Ok(node.JsonData);

            return BadRequest("под вашим управлением нет ноды с таким айди");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddNode(Guid projectId, string name, string jsonData)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = TokenService.GetUserFromToken(authHeader);

            var proj = user.Projects.Where(p => p.Id == projectId).FirstOrDefault();

            if (proj != null)
            {
                var node = new NodeGraph(name, proj.Id, jsonData);
                proj.Nodes.Add(node);
                return Ok(node);
            }
            else
            {
                return BadRequest("такого проекта нет");
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateNode(Guid id, string name, string jsonData)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = TokenService.GetUserFromToken(authHeader);

            var node = user.Projects.SelectMany(p => p.Nodes).FirstOrDefault(n => n.Id == id);

            node.Name = name ?? node.Name;
            node.JsonData = jsonData ?? node.JsonData;

            if (node != null)
                return Ok(node);
            
            return BadRequest("под вашим управлением нет ноды с таким айди");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteNode(Guid id)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = TokenService.GetUserFromToken(authHeader);

            var node = user.Projects.SelectMany(p => p.Nodes).FirstOrDefault(n => n.Id == id);

            if (node != null)
            {
                var proj = user.Projects.Where(p => p.Id == node.ProjectId).FirstOrDefault();
                proj.Nodes.Remove(node);
                return Ok(node);
            }

            return BadRequest("под вашим управлением нет ноды с таким айди");
        }
    }
}
