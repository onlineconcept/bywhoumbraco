using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using Dev.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Dev.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IOptions<AppSettings> _appSettings;

        public AdminController(IAdminService adminService, IOptions<AppSettings> appSettings)
        {
            _adminService = adminService;
            _appSettings = appSettings;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("admin/orders/getorders")]
        public async Task<IActionResult> GetOrders([FromQuery] string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = GetValidationParameters();

                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
                if (validatedToken != null)
                {
                    return Ok(await _adminService.GetOrders());
                }
                else
                {
                    return Ok(new{ Error=true, StatusCode= 401});
                }
            }
            catch (Exception ex)
            {
                return Ok(new{ Error=true, StatusCode= 401});
            }
        }

        [Route("admin/styles/getstyles")]
        public async Task<IActionResult> GetStyles([FromQuery] string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = GetValidationParameters();

                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
                if (validatedToken != null)
                {
                    var styles = await _adminService.GetStyles();
                    return Ok(styles.ToList());
                }
                else
                {
                    return Ok(new{ Error=true, StatusCode= 401});
                }
            }
            catch (Exception ex)
            {
                return Ok(new{ Error=true, StatusCode= 401});
            }
        }

        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = false, // Because there is no expiration in the generated token
                ValidateAudience = false, // Because there is no audiance in the generated token
                ValidateIssuer = false, // Because there is no issuer in the generated token
                ValidIssuer = "Sample",
                ValidAudience = "Sample",
                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_appSettings.Value
                            .Secret)) // The same key as the one that generate the token
            };
        }
    }
}