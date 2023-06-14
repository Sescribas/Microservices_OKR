using Microsoft.AspNetCore.Mvc;
using Domain;

namespace Identity.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly List<User> Users = new List<User>
        {
            new User
            {
                Id=1,
                UserName = "Sescribas",
                Email = "santi.escribas@hotmail.com",
                Dni = "39966396"
            }
        };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUsers")]
        public IEnumerable<User> Get()
        {
            _logger.LogInformation("Se comenzo el pedido de usuarios.");
            return Users;
        }
    }
}