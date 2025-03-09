using FinPlanXBackend.Data;
using FinPlanXBackend.Models;
using FinPlanXBackend.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;

namespace FinPlanXBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(AppDbContext context, IConfiguration configuration) : ControllerBase
    {
        private readonly AppDbContext _context = context;
        private readonly IConfiguration _configuration = configuration;

        // POST: api/Users/Register
        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(RegisterDto registerDto)
        {
            var user = new User
            {
                Username = registerDto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.PasswordHash),
                Role = registerDto.Role ?? "User"
            }; 
            // Hash the password before saving
            

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        // POST: api/Users/Login
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(LoginDto loginDto)
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == loginDto.Username);
            if (dbUser == null || !BCrypt.Net.BCrypt.Verify(loginDto.PasswordHash, dbUser.PasswordHash))
                return Unauthorized("Invalid username or password");

            // Generate JWT token
            var token = GenerateJwtToken(dbUser);
            return Ok(new { token = token});
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: new[] { 
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                },
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}