using Identity.api.Models;
using Identity.api.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Identity.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private static UserModel User = new();
        private readonly ILogger<UserModel> _logger;
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration, ILogger<UserModel> logger) 
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserModel>> Register(UserViewModel request) 
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
        public async Task<ActionResult<string>> Login(UserViewModel request)
        {
            if(User.UserName != request.UserName)
            {
                return BadRequest("El nombre de usuario es incorrecto.");
            }

            if (!VerifyPassword(request.Password, User.PasswordHash, User.PasswordSalt))
            {
                return BadRequest("La contraseña es incorrecta.");

            }

            string token = CreateToken(User);

            return Ok(token);
        }

        private string CreateToken(UserModel user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddHours(2), signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
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
