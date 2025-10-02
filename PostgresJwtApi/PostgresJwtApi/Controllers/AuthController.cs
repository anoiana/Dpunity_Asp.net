using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PostgresJwtApi.Datas;
using PostgresJwtApi.Dtos.Resquest;
using PostgresJwtApi.Models;


namespace PostgresJwtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            this._context = dbContext;
            this._configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest resquestDto)
        {
            if (await _context.Users.AnyAsync(u => u.Name == resquestDto.Username)) {
                return BadRequest("User name already exists!");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(resquestDto.Password);
            var user = new User
            {
                Name = resquestDto.Username,
                PasswordHash = passwordHash,
                Role = resquestDto.Role,
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(new {message = "User registered successfully!" });    
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginResquest resquestDto) 
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == resquestDto.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(resquestDto.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid credentials!");
            }
            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Name),
                new Claim(ClaimTypes.Role,user.Role),
                new Claim("UserId", user.Id.ToString())
            };
            var token = new JwtSecurityToken
                (
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
