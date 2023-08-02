using Microsoft.AspNetCore.Mvc;
using OKR.Common.Domain;
using OKR.Common.api.Models;
using OKR.Common.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.ComponentModel;
using System.Net.Mime;
using Swashbuckle.AspNetCore.Annotations;
using OKR.Common.api.Models.ViewModels;
using MediatR;
using Identitty.Services.EventHandlers.Commands;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OKR.Common.api.Controllers
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

        [HttpGet("getall")]
        [Description("Obtiene un listado de usuarios.")]
        public IEnumerable<User> Get()
        {
            var users = _userService.GetUsers();
            
            return users;
        }

        [HttpPost("create")]
        [SwaggerOperation(Summary = "Crea un nuevo usuario.", Tags = new[] { "User" })]
        [ProducesResponseType(typeof(UserCreateCommand), StatusCodes.Status201Created)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> Create([FromBody] UserCreateCommand command)
        {
            var result =  await _mediator.Send(command);

            return result.Success ? Ok() : BadRequest(result);
        }

        [HttpPut("update/{user_id}")]
        [SwaggerOperation(Summary = "Se modifica un usuario.", Tags = new[] { "User" })]
        [ProducesResponseType(typeof(UserUpdateCommand), StatusCodes.Status201Created)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> Update([FromBody] UserUpdateCommand command, [FromRoute(Name = "user_id")] int userId)
        {
            command.Id = userId;
            var result = await _mediator.Send(command);

            return result.Success ? Ok() : BadRequest(result);
        }

        [HttpDelete("delete/{user_id}")]
        [SwaggerOperation(Summary = "Se elimina un usuario.", Tags = new[] { "User" })]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> Delete([FromRoute(Name = "user_id")] int userId)
        {
            var result = await _mediator.Send(new UserDeleteCommand(userId));

            return result.Success ? Ok() : BadRequest(result);
        }

    }
}