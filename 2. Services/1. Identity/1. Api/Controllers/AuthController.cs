using Identity.api.Models;
using Identity.api.Models.DtoS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Identity.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private static UserModel User = new();
        private ILogger<UserModel> _logger;

        public AuthController(ILogger<UserModel> logger) 
        {
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserModel>> Register(UserDto request) 
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passworSalt);
            User.UserName = request.UserName;
            User.PasswordHash = passwordHash;
            User.PasswordSalt = passworSalt;
            return Ok(User);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passworSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passworSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
