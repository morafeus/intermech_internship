using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebAPI_internship.Models;
using WebAPI_internship.Models.NodeModels;
using WebAPI_internship.Services;
using WebAPI_internship.Services.Interfaces;

namespace WebAPI_internship.Controllers
{
    [ApiController]
    [Route("api/nodegraph")]
    public class NodeGraphController : Controller
    {

        private readonly ITokenService _tokenService;
        private readonly INodeGraphService _nodeGraphService;

        public NodeGraphController(ITokenService tokenService, INodeGraphService nodeGraphService)
        {
            _tokenService = tokenService;
            _nodeGraphService = nodeGraphService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetNodes(Guid projectId)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = _tokenService.GetUserFromToken(authHeader);

            try
            {
                var nodes = await _nodeGraphService.GetNodes(projectId, user.Id);
                return Ok(nodes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetNode(Guid id)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = _tokenService.GetUserFromToken(authHeader);

            try
            {
                var node = await _nodeGraphService.GetNodeById(id, user.Id);
                return Ok(node.JsonData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddNode(Guid projectId, string name, string jsonData)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = _tokenService.GetUserFromToken(authHeader);

            try
            {
                var node = await _nodeGraphService.AddNode(projectId, name, jsonData, user.Id);
                return Ok(node.JsonData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateNode(Guid id, string? name, string? jsonData)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = _tokenService.GetUserFromToken(authHeader);

            try
            {
                var node = await _nodeGraphService.ChangeNode(id,user.Id,  name, jsonData);
                return Ok(node.JsonData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteNode(Guid id)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = _tokenService.GetUserFromToken(authHeader);

            try
            {
                var node = await _nodeGraphService.RemoveNode(id, user.Id);
                return Ok(node.JsonData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
