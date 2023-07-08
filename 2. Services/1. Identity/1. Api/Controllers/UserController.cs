using Microsoft.AspNetCore.Mvc;
using Domain;
using Identity.api.Models;
using Identity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.ComponentModel;

namespace Identity.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("Get")]
        [Description("Obtiene un listado de usuarios.")]
        public IEnumerable<User> Get()
        {
            _logger.LogInformation("Se comenzo el pedido de usuarios.");
            var users = _userService.GetUsers();
            
            return users;
        }

        [HttpGet("GetById")]
        [Description("Obtiene un usuario por id.")]
        public IEnumerable<User> GetUserById()
        {
            _logger.LogInformation("Se comenzo el pedido de usuarios.");
            return null;
        }

        [HttpPost("Create")]
        [Description("Create an User")]
        public Task<IActionResult> Create()
        {
            return null;
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