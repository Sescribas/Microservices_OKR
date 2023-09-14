using OKR.Common.api.Models;
using OKR.Common.api.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Identitty.Services.EventHandlers;
using OKR.Common.Services.Interfaces;
using MediatR;
using Identitty.Services.EventHandlers.Commands;
using System.Collections;
using System.Text;
using System.Xml.Linq;

namespace OKR.Common.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private static UserModel User = new();
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly IUserService _userService;

        public AuthController(IConfiguration configuration, IMediator mediator, IUserService userService)
        {
            _configuration = configuration;
            _mediator = mediator;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserModel>> Register(UserViewModel request) 
        {

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passworSalt);
            User.UserName = request.UserName;
            User.PasswordHash = passwordHash;
            User.PasswordSalt = passworSalt;

            var userCreate = MapToUserCreateCommand(User, request);

            var result = await _mediator.Send(userCreate);

            return Ok(result);
        }

        private UserCreateCommand MapToUserCreateCommand(UserModel user, UserViewModel request)
        {
            return new UserCreateCommand()
            {
                UserName = user.UserName,
                Password = Encoding.UTF8.GetString(user.PasswordHash),
                Name = request.Name,
                LastName = request.LastName,
                Dni = request.Dni,
                Email = request.Email
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserViewModel request)
        {
            var user = _userService.GetByUserName(request.UserName);

            if (user == null)            
                return BadRequest("Username Inexistente.");       

            if (!VerifyPassword(request.Password, User.PasswordHash, User.PasswordSalt))            
                return BadRequest("La contraseña es incorrecta.");

            

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

            using (var hmac = new HMACSHA512())
            {
                passworSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
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
