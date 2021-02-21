using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataLayer.DTO.Auth;
using Dev.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Dev.Controllers
{
    public class AuthController: Controller
    {
        private readonly IAuthService _authService;
        private readonly IOptions<AppSettings> _appSettings;

        public AuthController(IAuthService authService,IOptions<AppSettings> appSettings)
        {
            _authService = authService;
            _appSettings = appSettings;
        }
        
        [Route("auth/login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] RegisterAndLoginDTO dto)
        {
            var user = await _authService.Login(dto);
            if (user == null)
                return Unauthorized(null);
            if (!PasswordHelper.VerifyHashedPassword(user.Password, dto.Password))
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userid", user.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new {
                token = tokenHandler.WriteToken(token),
                User = new
                {
                    username = user.Username
                    
                }
            });
            
        }
        [Route("auth/register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterAndLoginDTO dto)
        {
            dto.Password = PasswordHelper.HashPassword(dto.Password);
            var user = await _authService.Register(dto);
            return View();
        }
    }
}