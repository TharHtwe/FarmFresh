using FarmFresh_API.Data;
using FarmFresh_API.Helpers;
using FarmFresh_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly FarmFreshDdContext _farmFreshDdContext;

        public AdminController(FarmFreshDdContext farmFreshDdContext)
        {
            _farmFreshDdContext = farmFreshDdContext;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Admin userRequest)
        {
            if (null == userRequest)
                return BadRequest();

            var admin = await _farmFreshDdContext.Admins.FirstOrDefaultAsync(x => x.Email == userRequest.Email);
            if (null == admin || !PasswordHasher.VerifyPassword(userRequest.Password, admin.Password))
            {
                return NotFound(new { Message = "User not found." });
            }

            admin.Token = CreateJWTToken(admin);

            return Ok(new { Token = admin.Token });
        }

        private string CreateJWTToken(Admin user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("verysecurekey2...");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            return jwtTokenHandler.WriteToken(token);
        }
    }
}
