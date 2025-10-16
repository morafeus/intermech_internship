using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI_internship.Services.Interfaces;

namespace WebAPI_internship.Controllers
{
    [ApiController]
    [Route("api/nodegraph")]
    public class NodeExecutionController : Controller
    {
        private readonly INodeExecutorService _executor;
        private readonly ITokenService _tokenService;

        public NodeExecutionController(INodeExecutorService executor, ITokenService tokenService)
        {
            _executor = executor;
            _tokenService = tokenService;
        }

        [HttpPost("{id}/execute")]
        [Authorize]
        public async Task<IActionResult> Execute(Guid id)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = _tokenService.GetUserFromToken(authHeader);

            var node = Store.Nodes.Where(n => n.Id == id).FirstOrDefault();
            if (node == null)
                return BadRequest("в проекте нет ноды с таким айди");

            var proj = Store.Projects.Where(p => (p.Id == node.ProjectId) && (p.UserId == user.Id)).FirstOrDefault();
            if (proj == null)
                return BadRequest("у вас нет доступа к проекту, которому принадлежит эта нода");

            var result = _executor.ExecuteAsync(node.JsonData);
            return Ok(result.Result);
        }

    }
}
