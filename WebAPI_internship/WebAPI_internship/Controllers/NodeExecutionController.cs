using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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

        /// <response code="200">нода была выполнена</response>
        /// <response code="400">ошибка, нода с таким айди не может быть выполнена</response>
        [HttpPost("{id}/execute")]
        [Authorize]
        public async Task<IActionResult> Execute([Required]  Guid id)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = _tokenService.GetUserFromToken(authHeader);

            var node = Store.Nodes.Where(n => n.Id == id).FirstOrDefault();
            if (node == null)
                return BadRequest("в проекте нет ноды с таким айди");

            var proj = Store.Projects.Where(p => (p.Id == node.ProjectId) && (p.UserId == user.Id)).FirstOrDefault();
            if (proj == null)
                return BadRequest("у вас нет доступа к проекту, которому принадлежит эта нода");

            try
            {
                var result = _executor.ExecuteAsync(node.JsonData);
                return Ok(result.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
