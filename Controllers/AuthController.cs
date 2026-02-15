using ATMDotNetCoreApp.DB;
using ATMDotNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ATMDotNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel loginModel)
        {
            if (loginModel.AccNo == null && loginModel.ActPin == null) return BadRequest();

            var user = _appDbContext.Logins.FirstOrDefault(l => l.AccNo == loginModel.AccNo && l.ActPin == loginModel.ActPin);
            if (user == null) return Unauthorized();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            // key generally kept in Keyvault.

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddHours(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );


            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

    }
}
