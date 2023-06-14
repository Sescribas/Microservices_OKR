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
            _logger.LogInformation("Comienza la operacion de registracion.");

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passworSalt);
            User.UserName = request.UserName;
            User.PasswordHash = passwordHash;
            User.PasswordSalt = passworSalt;

            _logger.LogInformation("Finaliza la operacion de registracion.");

            return Ok(User);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            if(User.UserName != request.UserName)
            {
                return BadRequest("No existe el usuario con ese nombre de usuario.");
            }

            if (!VerifyPassword(request.Password, User.PasswordHash, User.PasswordSalt))
            {
                return BadRequest("El usuario o la contraseña es incorrecta.");

            }

            return Ok("Login");
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passworSalt)
        {
            _logger.LogInformation("Comienza la operacion de hasheo.");

            using (var hmac = new HMACSHA512())
            {
                passworSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            _logger.LogInformation("Finaliza la operacion de hasheo.");

        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passworSalt)
        {
            using (var hmac = new HMACSHA512(User.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
