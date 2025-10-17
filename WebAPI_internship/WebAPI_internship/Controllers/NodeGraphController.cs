using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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

        /// <param name="projectId">идентификатор проекта, который принадлежит пользователю</param>
        /// <response code="200">список нод данного проекта</response>
        /// <response code="400">ошибка, если у пользователя нет доступа к проекту по айди</response>
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

        /// <param name="id">идентефикатор ноды, принадлежащей проекту пользователя</param>
        /// <response code="200">нода с указанным идентификатором</response>
        /// <response code="400">ошибка, если у пользователя нет доступа к данной ноде</response>
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

        /// <remarks>
        /// Sample request:
        ///
        ///     Post /add
        ///     {
        ///        "projectId": ""..\..\WebAPI_internship\ClientCustomNodes\bin\Debug\ClientCustomNodes.dll""
        ///        "name": "my node"
        ///        "jsonData": "
        ///        {
        ///              "nodes": [
        ///                {
        ///                  "Id": "b2c3d4e5-0001-4000-0000-000000000011",
        ///                  "Name": "AddNumberNode", 
        ///                  "Params": {
        ///                    "A": 10,
        ///                    "B": 20
        ///                  },
        ///                  "Inputs": {}
        ///                },
        ///                {
        ///                "Id": "c3d4e5f6-0001-4000-0000-000000000022",
        ///                  "Name": "MultipleNumberNode", 
        ///                  "Params": {
        ///                    "B": 5
        ///                  },
        ///                  "Inputs": {
        ///                   "A": {
        ///                        "NodeId": "b2c3d4e5-0001-4000-0000-000000000011",
        ///                      "OutputName": "Result"
        ///                    }
        ///                }
        ///            },
        ///                {
        ///                "Id": "d4e5f6c7-0001-4000-0000-000000000033",
        ///                  "Name": "ConsoleLogNode", 
        ///                  "Params": { },
        ///                  "Inputs": {
        ///                    "Value": {
        ///                       "NodeId": "c3d4e5f6-0001-4000-0000-000000000022",
        ///                      "OutputName": "Result"
        ///                    }
        ///                }
        ///            },
        ///                {
        ///                "Id": "e5f6c7d8-0001-4000-0000-000000000044",
        ///                  "Name": "StringConcatNode", 
        ///                   "Params": {
        ///                    "String1": "Hello", 
        ///                    "String2": "World"
        ///                  },
        ///                  "Inputs": { }
        ///           }]
        ///         }
        ///         "
        ///     }
        ///
        /// </remarks>
        /// <param name="projectId">идентификатор проекта, который принадлежит пользователю</param>
        /// <response code="200">идентификатор ноды, успешно добавленной на проект</response>
        /// <response code="400">ошибка, если у пользователя нет доступа к данному проекту или нода не была создана</response>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddNode([Required] Guid projectId, [Required] string name, [Required] string jsonData)
        {
            var authHeader = Request.Headers["Authorization"];
            var user = _tokenService.GetUserFromToken(authHeader);

            try
            {
                var node = await _nodeGraphService.AddNode(projectId, name, jsonData, user.Id);
                return Ok(node.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <param name="id">идентефикатор ноды, принадлежащей проекту пользователя</param>
        /// <response code="200">измененная нода с указанным идентификатором</response>
        /// <response code="400">ошибка, если у пользователя нет доступа к данной ноде</response>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateNode([Required] Guid id, string? name, string? jsonData)
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

        /// <param name="id">идентефикатор ноды, принадлежащей проекту пользователя</param>
        /// <response code="200">удаленная нода с указанным идентификатором</response>
        /// <response code="400">ошибка, если у пользователя нет доступа к данной ноде</response>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteNode([Required] Guid id)
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
