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
    [Route("api")]
    public class UserController : Controller
    {
        private readonly FarmFreshDdContext _farmFreshDdContext;

        public UserController(FarmFreshDdContext farmFreshDdContext)
        {
            _farmFreshDdContext = farmFreshDdContext;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userRequest)
        {
            if (null == userRequest)
                return BadRequest();

            var user = await _farmFreshDdContext.Users.FirstOrDefaultAsync(x => x.Email == userRequest.Email);
            if (null == user || !PasswordHasher.VerifyPassword(userRequest.Password, user.Password))
            {
                return NotFound(new { Message = "User not found." });
            }

            user.Token = CreateJWTToken(user);

            return Ok(new { Token = user.Token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User userRequest)
        {
            if (null == userRequest)
                return BadRequest();

            if (await CheckEmailExistAsync(userRequest.Email))
                return BadRequest(new { Message = "User already exist." });

            userRequest.Password = PasswordHasher.HashPassword(userRequest.Password);
            userRequest.Token = "";
            await _farmFreshDdContext.Users.AddAsync(userRequest);
            await _farmFreshDdContext.SaveChangesAsync();

            return Ok(userRequest);
        }

        private Task<bool> CheckEmailExistAsync(string email) 
            => _farmFreshDdContext.Users.AnyAsync(x => x.Email == email);

        private string CreateJWTToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("verysecurekey...");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
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
