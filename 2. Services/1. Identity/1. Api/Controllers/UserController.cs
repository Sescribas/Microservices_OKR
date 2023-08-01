using Microsoft.AspNetCore.Mvc;
using Domain;
using Identity.api.Models;
using Identity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.ComponentModel;
using System.Net.Mime;
using Swashbuckle.AspNetCore.Annotations;
using Identity.api.Models.ViewModels;
using MediatR;
using Identitty.Services.EventHandlers.Commands;
namespace Identity.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMediator _mediator;

        public UserController( IUserService userService, IMediator mediator)
        {
            _userService = userService;
            _mediator = mediator;
        }

        [HttpGet("Get")]
        [Description("Obtiene un listado de usuarios.")]
        public IEnumerable<User> Get()
        {
            var users = _userService.GetUsers();
            
            return users;
        }

        [HttpGet("GetById")]
        [Description("Obtiene un usuario por id.")]
        public IEnumerable<User> GetUserById()
        {
            return null;
        }

        [HttpPost("Create User")]
        [SwaggerOperation(Summary = "Crea un nuevo usuario.", Tags = new[] { "User" })]
        [ProducesResponseType(typeof(UserCreateCommand), StatusCodes.Status201Created)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> Create([FromBody] UserCreateCommand command)
        {
            var result =  await _mediator.Send(command);

            return result.Success ? Ok() : BadRequest(result);
        }

        [HttpPut("Update")]
        [Description("Update an User")]

        public Task<IActionResult> Update()
        {
            return null;
        }

        [HttpDelete("Delete")]
        [Description("Delete an User")]
        public Task<IActionResult> Delete()
        {
            return null;
        }

    }
}