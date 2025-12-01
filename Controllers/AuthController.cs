using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductsApi.Data;
using ProductsApi.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        public AuthController(IConfiguration configuration , AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }





        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {


            var User = _context.Users.FirstOrDefault(u => u.Username == loginDto.Username);
            if (User == null)
            {
                throw new Exception("User not in Database");
            }

            var hmac = new HMACSHA512(User.PasswordSalt);


            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));


            for (var i = 0; i < passwordHash.Length; i++)
            {
                if (passwordHash[i] != User.PasswordHash[i])
                {
                    throw new Exception("Incorrect password");
                }
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, loginDto.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return Ok(new { token = jwt });
        }
    }
}