using EmployeeManagement.Application.Dtos.Request;
using EmployeeManagement.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Application.Dtos.Response;

namespace EmployeeManagement.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public AuthController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }


        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            var user = await _userService.AuthenticateAsync(loginRequest.Username, loginRequest.Password);
            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }
            var claims = new List<Claim>
            { 
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var tokenString = _tokenService.CreateToken(claims);
            return Ok(new LoginResponseDto { Token = tokenString });
        }

        [HttpPost("register")]
        
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequest)
        {
            try
            {
                var newUser = await _userService.RegisterAsync(registerRequest);
                return Ok(newUser);
            }
            catch (System.ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
